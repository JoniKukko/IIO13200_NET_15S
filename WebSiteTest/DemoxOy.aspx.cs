using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class DemoxOy : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        // ladataan asiakastiedot tietokannasta
        GetRealData();

    }



    protected void GetDemoData()
    {
        // täytetään gridview
        DataTable dt = JAMK.IT.DBDemoxOy.GetDataSimple();
        gvCustomers.DataSource = dt;
        gvCustomers.DataBind();
    }



    protected void GetRealData()
    {
        // täytetään gridview
        try
        {
            DataTable dt = JAMK.IT.DBDemoxOy.GetDataReal(ConfigurationManager.ConnectionStrings["CustomersCSTR"].ConnectionString);
            gvCustomers.DataSource = dt;
            gvCustomers.DataBind();
        }
        catch (Exception e)
        {
            errorMessage.Text = "VIRHE: " + e.Message;
        }
    }



}