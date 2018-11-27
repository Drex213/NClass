using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NClass.Core.ObjectReferences
{
    [DebuggerDisplay("{Name}")]
    public class ObjectReference
    {
        public ObjectReference()
        {
        }

        public ObjectReference(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Deserialize(XmlElement node)
        {
            var nameNode = node["Name"];
            if (nameNode == null)
                throw new InvalidDataException("ObjectReference's Name element is missing.");
            Name = nameNode.InnerText;
        }

        public void Serialize(XmlElement node)
        {
            XmlElement nameElement = node.OwnerDocument.CreateElement("Name");
            nameElement.InnerText = Name;
            node.AppendChild(nameElement);
        }
    }
}
