using NClass.Core.ObjectReferences.TypeReferences;
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

        public static ObjectReference Create(IEntity element)
        {
            var typeBase = element as TypeBase;

            if (element is ClassType)
                return new ClassReference(typeBase);

            if (element is DelegateType)
                return new DelegateReference(typeBase);

            if (element is EnumType)
                return new EnumReference(typeBase);

            if (element is InterfaceType)
                return new InterfaceReference(typeBase);

            if (element is StructureType)
                return new StructureReference(typeBase);

            throw new ArgumentException($"An ObjectReference with typename of '{element.GetType().Name}' cannot be instanciated.");
        }

        protected List<Element> referredElements = new List<Element>();

        public event EventHandler Modified;

        public event EventHandler Removed;

        public ObjectReference()
        {
        }

        public ObjectReference(TypeBase element)
        {
            Name = element.Name;
            AddReferredElement(element);
        }

        public string Name { get; protected set; }

        public virtual string IconImageKey => "type-builtin";

        public bool TryDelete()
        {
            if (referredElements.Count > 0)
                return false;

            OnRemoved(EventArgs.Empty);
            return true;
        }

        public void AddReferredElement(TypeBase element)
        {
            referredElements.Add(element);
            element.Modified += Element_Modified;
            element.Removed += Element_Removed;
        }

        private void RemoveReferredElement(TypeBase element)
        {
            element.Removed -= Element_Removed;
            element.Modified -= Element_Modified;
            referredElements.Remove(element);

            if (referredElements.Count == 0)
                OnRemoved(EventArgs.Empty);
        }

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
            Modified?.Invoke(this, e);
        }

        private void OnRemoved(EventArgs e)
        {
            Removed?.Invoke(this, e);
        }

        private void Element_Modified(object sender, EventArgs e)
        {
            var element = (TypeBase)sender;
            Name = element.Name;
            OnModified(EventArgs.Empty);
        }

        private void Element_Removed(object sender, EventArgs e)
        {
            var element = (TypeBase)sender;
            RemoveReferredElement(element);
        }
    }
}
