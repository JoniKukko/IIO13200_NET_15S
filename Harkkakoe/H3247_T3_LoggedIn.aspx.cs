using System;
using System.Web.Configuration;
using System.Xml.Serialization;

public partial class H3247_T3_LoggedIn : System.Web.UI.Page
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
        // var temp = new T3Practice();
        // temp.travel = 10;
        // this.user.practices.Add(temp);
        if (this.user == null)
        {
            Response.Redirect("H3247_T3A.aspx");
        }
        this.showData();
    }


    
    private void showData()
    {
        gridviewData.DataSource = this.user.practices;
        gridviewData.DataBind();
    }

    protected void buttonLogout_Click(object sender, EventArgs e)
    {
        this.user = null;
        this.XMLdata = null;
        Response.Redirect("H3247_T3A.aspx");
    }

    protected void buttonSave_Click(object sender, EventArgs e)
    {
        
    }
}