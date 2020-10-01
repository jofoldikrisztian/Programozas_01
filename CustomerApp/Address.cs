using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CustomerApp
{
    public class Address
    {
        [XmlIgnore] 
        public int id;
        [XmlAttribute] 
        public string name;
        [XmlElement(IsNullable = false)]
        public string street;
        [XmlElement(IsNullable = false)]
        public string city;
        [XmlElement(IsNullable = false)]
        public string state;
        [XmlElement(IsNullable = false)]
        public string zip;
    }
}
