using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RustyDragon
{
    public class CheeseList
    {
        [XmlElement("Item")]
        public List<Cheese> Cheese { get; set; }
    }
}
