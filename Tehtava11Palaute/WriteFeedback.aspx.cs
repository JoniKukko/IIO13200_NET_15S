using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class WriteFeedback : System.Web.UI.Page
{
    private XElement feedbackFile;
    private List<Feedback> feedbacks;



    protected void Page_Load(object sender, EventArgs e)
    {
    }



    protected void textboxDate_Validate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = !(
                textboxDate.SelectedDate == null ||
                textboxDate.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0)
            );
    }



    // xml tiedoston lataaminen
    private bool loadXMLfile()
    {
        try
        {
            // tiedoston sisältö xelement tiedostoon
            this.feedbackFile = XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/Palautteet.xml"));
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }



    // Haetaan palautteet xelement tiedostosta
    private bool parseFeedbacks()
    {
        // haetaan elementit xml filestä
        IEnumerable<Feedback> feedbackQuery =
            (from feedback in this.feedbackFile.Elements("palaute")
             select new Feedback(
                     feedback.Element("pvm").Value,
                     feedback.Element("tekija").Value,
                     feedback.Element("opintojaksonimi").Value,
                     feedback.Element("opintojaksokoodi").Value,
                     feedback.Element("opittu").Value,
                     feedback.Element("haluanoppia").Value,
                     feedback.Element("hyvaa").Value,
                     feedback.Element("parannettavaa").Value,
                     feedback.Element("muuta").Value
                 )
            );

        // muodostetaan siitä lista
        this.feedbacks = feedbackQuery.ToList();
        return true;
    }



    // palautteen tallennus
    private bool saveFeedback(Feedback newFeedback)
    {

        try
        {
            // lisätään xelement tiedostoon
            this.feedbackFile.Add(
                    new XElement("palaute",
                        new XElement("pvm", newFeedback.Date),
                        new XElement("tekija", newFeedback.Name),
                        new XElement("opintojaksonimi", newFeedback.ClassName),
                        new XElement("opintojaksokoodi", newFeedback.ClassCode),
                        new XElement("opittu", newFeedback.Learned),
                        new XElement("haluanoppia", newFeedback.WantToLearn),
                        new XElement("hyvaa", newFeedback.Good),
                        new XElement("parannettavaa", newFeedback.Bad),
                        new XElement("muuta", newFeedback.Other)
                    )
                );

            // yritetään tallentaa xelement tiedostoa
            this.feedbackFile.Save(HttpContext.Current.Server.MapPath("~/App_Data/Palautteet.xml"));
            
        }
        catch (Exception)
        {
            return false;
        }
        return true;

    }


    
    protected void buttonSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            try {
                // rakennetaan olio
                Feedback newFeedback = new Feedback(
                    textboxDate.SelectedDate.ToString(),
                    textboxName.Text,
                    textboxClassName.Text,
                    textboxClassCode.Text,
                    textboxLearned.Text,
                    textboxWantToLearn.Text,
                    textboxGood.Text,
                    textboxBad.Text,
                    textboxOther.Text
                    );

                this.loadXMLfile();
                this.parseFeedbacks();
                this.saveFeedback(newFeedback);
                Response.Redirect("ReadFeedback.aspx");

            } 
            catch(Exception ex)
            {
            }

        }
    }


}