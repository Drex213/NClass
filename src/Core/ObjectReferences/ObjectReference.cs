using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NClass.Core.ObjectReferences
{
    [DebuggerDisplay("{Name}")]
    public abstract class ObjectReference
    {
        public static ObjectReference Create(string typeName)
        {
            var assembly = Assembly.GetAssembly(typeof(ObjectReference));
            var referenceTypes = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ObjectReference)));
            var targetType = referenceTypes.FirstOrDefault(t => t.Name == typeName);

            if (targetType == null)
                throw new ArgumentException($"An ObjectReference with typename of '{typeName}' cannot be instanciated.");

            return (ObjectReference)Activator.CreateInstance(targetType);
        }

        public ObjectReference()
        {
        }

        public ObjectReference(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }

        public virtual string IconImageKey => "type-builtin";

        public virtual void Deserialize(XmlElement node)
        {
            var nameNode = node["Name"];
            if (nameNode == null)
                throw new InvalidDataException("ObjectReference's Name element is missing.");
            Name = nameNode.InnerText;
        }

        public virtual void Serialize(XmlElement node)
        {
            XmlAttribute typeAttribute = node.OwnerDocument.CreateAttribute("type");
            typeAttribute.InnerText = GetType().Name;
            node.Attributes.Append(typeAttribute);

            XmlElement nameElement = node.OwnerDocument.CreateElement("Name");
            nameElement.InnerText = Name;
            node.AppendChild(nameElement);
        }
    }
}
