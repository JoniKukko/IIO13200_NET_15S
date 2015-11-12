using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class ReadFeedback : System.Web.UI.Page
{
    private XElement feedbackFile;
    private List<Feedback> feedbacks;


    protected void Page_Load(object sender, EventArgs e)
    {
        this.loadXMLfile();
        this.parseFeedbacks();
        this.addToTable();
    }


    // lisätään data tauluun
    private bool addToTable()
    {
        // EI NÄIN
        foreach(Feedback feedback in this.feedbacks)
        {
            // HYYYYYIIII
            TableRow feedbackRow = new TableRow();

            TableCell feedbackDate = new TableCell();
            TableCell feedbackName = new TableCell();
            TableCell feedbackClassName = new TableCell();
            TableCell feedbackClassCode = new TableCell();
            TableCell feedbackLearned = new TableCell();
            TableCell feedbackWantToLearn = new TableCell();
            TableCell feedbackGood = new TableCell();
            TableCell feedbackBad = new TableCell();
            TableCell feedbackOther = new TableCell();

            // HYYYYYIIII

            feedbackDate.Text = feedback.Date;
            feedbackName.Text = feedback.Name;
            feedbackClassName.Text = feedback.ClassName;
            feedbackClassCode.Text = feedback.ClassCode;
            feedbackLearned.Text = feedback.Learned;
            feedbackWantToLearn.Text = feedback.WantToLearn;
            feedbackGood.Text = feedback.Good;
            feedbackBad.Text = feedback.Bad;
            feedbackOther.Text = feedback.Other;

            // HYYYYYIIII

            feedbackRow.Cells.Add(feedbackDate);
            feedbackRow.Cells.Add(feedbackName);
            feedbackRow.Cells.Add(feedbackClassName);
            feedbackRow.Cells.Add(feedbackClassCode);
            feedbackRow.Cells.Add(feedbackLearned);
            feedbackRow.Cells.Add(feedbackWantToLearn);
            feedbackRow.Cells.Add(feedbackGood);
            feedbackRow.Cells.Add(feedbackBad);
            feedbackRow.Cells.Add(feedbackOther);

            // HYYYYYIIII

            feedbackTable.Rows.Add(feedbackRow);

            // HYYYYYIIII
        }
        // THERE MUST BE A BETTER WAY
        return true;
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



}