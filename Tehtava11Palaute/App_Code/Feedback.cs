using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Feedback
/// </summary>
public class Feedback
{
    public string Date { get; set; }
    public string Name { get; set; }
    public string ClassName { get; set; }
    public string ClassCode { get; set; }
    public string Learned { get; set; }
    public string WantToLearn { get; set; }
    public string Good { get; set; }
    public string Bad { get; set; }
    public string Other { get; set; }


    public Feedback(string Date, string Name, string ClassName, string ClassCode, string Learned, string WantToLearn, string Good, string Bad, string Other)
    {
        this.Date = Date;
        this.Name = Name;
        this.ClassName = ClassName;
        this.ClassCode = ClassCode;
        this.Learned = Learned;
        this.WantToLearn = WantToLearn;
        this.Good = Good;
        this.Bad = Bad;
        this.Other = Other;
    }


    // tarkistetaan ilmentymän tiedot
    public bool SanityCheck()
    {
        // rumaa lujaa ja nopeesti
        return !(
                (this.Date.Length == 0) ||
                (this.Name.Length == 0) ||
                (this.ClassName.Length == 0) ||
                (this.ClassCode.Length == 0) ||
                (this.Learned.Length == 0) ||
                (this.WantToLearn.Length == 0) ||
                (this.Good.Length == 0) ||
                (this.Bad.Length == 0) ||
                (this.Other.Length == 0)
            );
    }


}