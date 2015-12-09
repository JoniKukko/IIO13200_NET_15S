using System;
using System.Data;
using System.Linq;
using System.Web.Configuration;

public partial class H3247_T2 : System.Web.UI.Page
{

    private DataSet dataset = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack && this.loadXML() && this.gridCalculations())
        {
            labelMessages.Text = "Kaikki onnistui!";
        }
    }


    
    private bool loadXML()
    {
        try
        {
            this.dataset.ReadXml(Server.MapPath(WebConfigurationManager.AppSettings["XMLfilePath"]));
            gridviewCountries.DataSource = dataset;
            gridviewCountries.DataBind();
            
        } catch (Exception ex)
        {
            labelMessages.Text = "Virhe ladattaessa tiedostoa!";
            return false;
        }
        return true;
    }



    private bool gridCalculations()
    {
        try
        {
            var table = this.dataset.Tables[0].AsEnumerable();
            int countAsia = table.Where(x => x["Continent"].ToString() == "Asia").ToList().Count;
            long populationSum = table.Sum(x => long.Parse(x.Field<string>("Population")));

            labelCalculations.Text += "Continent Asia: " + countAsia.ToString() + "<br>Populaatio: " + populationSum.ToString();

        } catch (Exception ex)
        {
            labelMessages.Text = "Laskut epäonnistuivat!";
            return false;
        }
        return true;
    }
    
}