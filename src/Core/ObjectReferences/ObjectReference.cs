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

        protected List<Element> referredElements = new List<Element>();

        public event EventHandler Modified;

        public ObjectReference()
        {
        }

        public ObjectReference(TypeBase element)
        {
            referredElements.Add(element);
            Name = element.Name;
            element.Modified += Element_Modified;
        }

        public string Name { get; protected set; }

        public virtual string IconImageKey => "type-builtin";

        public virtual void Deserialize(XmlElement node)
        {
            var nameAttribute = node.Attributes["name"];
            if (nameAttribute == null)
                throw new InvalidDataException("ObjectReference's Name attribute is missing.");
            Name = nameAttribute.InnerText;
        }

        public virtual void Serialize(XmlElement node)
        {
            XmlAttribute typeAttribute = node.OwnerDocument.CreateAttribute("type");
            typeAttribute.InnerText = GetType().Name;
            node.Attributes.Append(typeAttribute);

            XmlAttribute nameAttribute = node.OwnerDocument.CreateAttribute("name");
            nameAttribute.InnerText = Name;
            node.Attributes.Append(nameAttribute);
        }

        private void OnModified(EventArgs e)
        {
            if (Modified != null)
                Modified(this, e);
        }

        private void Element_Modified(object sender, EventArgs e)
        {
            var element = (TypeBase)sender;
            Name = element.Name;
            OnModified(EventArgs.Empty);
        }
    }
}
