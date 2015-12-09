using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

[XmlRoot("USERS")]
public class T3XMLdata
{
    [XmlElement("USER")]
    public List<T3User> users = new List<T3User>();
}