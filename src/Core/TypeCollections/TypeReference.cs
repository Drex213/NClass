using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NClass.Core.TypeCollections
{
    public class TypeReference
    {
        public string Name { get; set; }

        public void Deserialize(XmlElement node)
        {
            var nameNode = node["Name"];
            if (nameNode == null)
                throw new InvalidDataException("TypeReference's Name element is missing.");
            Name = nameNode.InnerText;
        }
    }
}
