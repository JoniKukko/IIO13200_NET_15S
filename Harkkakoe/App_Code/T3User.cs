using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("USER")]
public class T3User
{
    [XmlElement("USERNAME")]
    public string username;

    [XmlElement("HASH")]
    public string hash;

    [XmlElement("PRACTICES")]
    public List<T3Practice> practices = new List<T3Practice>();
}