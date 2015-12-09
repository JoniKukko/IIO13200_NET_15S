using System;
using System.Xml.Serialization;

[XmlRoot("PRACTICES")]
public class T3Practice
{
    [XmlElement("STARTTIME")]
    public DateTime starttime;

    [XmlElement("ENDTIME")]
    public DateTime endtime;

    [XmlElement("TRAVEL")]
    public int travel;
}