using System;
using System.Web.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public partial class H3247_T3A : System.Web.UI.Page
{
    private T3XMLdata XMLdata = new T3XMLdata();
    private T3User user = new T3User();
    private bool loggedIn = false;


    protected void Page_Load(object sender, EventArgs e)
    {
        this.loadXML();
    }



    private bool loadXML()
    {
        try {
            string path = Server.MapPath(WebConfigurationManager.AppSettings["T3filePath"]);
            XmlSerializer serializer = new XmlSerializer(typeof(T3XMLdata));

            using (XmlTextReader xml = new XmlTextReader(path))
            {
                this.XMLdata = serializer.Deserialize(xml) as T3XMLdata;
            }

        } catch (Exception ex)
        {
            labelMessages.Text = "Virhe ladattaessa tiedostoa!";
            return false;
        }
        return true;
    }




    protected void buttonLogin_Click(object sender, EventArgs e)
    {
        string username = textboxUsername.Text;
        string password = textboxPassword.Text;
        string hash = sha256_hash(password);

        this.user = this.XMLdata.users.Where(user 
                => user.username == username 
                && user.hash == hash
            ).SingleOrDefault();

        if (this.user != null)
        {
            this.loggedIn = true;
        }
    }



    private string sha256_hash(String value)
    {
        StringBuilder builder = new StringBuilder();

        using (SHA256 hash = SHA256Managed.Create())
        {
            Encoding encoding = Encoding.UTF8;
            Byte[] result = hash.ComputeHash(encoding.GetBytes(value));

            foreach (Byte b in result)
                builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }


}