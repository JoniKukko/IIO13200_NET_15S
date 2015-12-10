using System;
using System.Web.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public partial class H3247_T3A : System.Web.UI.Page
{

    private T3XMLdata XMLdata {
        get { return (T3XMLdata)Session["XMLdata"]; }
        set { Session["XMLdata"] = value; }
    }
    private T3User user {
        get { return (T3User)Session["user"]; }
        set { Session["user"] = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.user != null)
        {
            Response.Redirect("H3247_T3_LoggedIn.aspx");
        }
        if (this.XMLdata == null)
        {
            this.loadXML();
        }
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
            Response.Redirect("H3247_T3_LoggedIn.aspx");
        }

        labelMessages.Text = "Väärä käyttäjätunnus tai salasana!";
    }



    private string sha256_hash(String value)
    {
        StringBuilder builder = new StringBuilder();

        using (SHA256 hash = SHA256Managed.Create())
        {
            Encoding encoding = Encoding.UTF8;
            Byte[] result = hash.ComputeHash(encoding.GetBytes(value));

            foreach (Byte b in result)
            {
                builder.Append(b.ToString("x2"));
            }
        }

        return builder.ToString();
    }
}