using NClass.Translations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NClass.Core.ObjectReferences
{
    public class TypeReferenceCollection : ObjectReferenceCollection
    {
        public TypeReferenceCollection()
        {
        }

        public TypeReferenceCollection(Language language)
        {
            Language = language;
            var references = language.TypeKeywords.Select(rn => new ObjectReference(rn));
            ObjectReferences.AddRange(references);
        }

        public Language Language { get; set; }

        public override string Name => $"{Strings.LanguageTypes} ({Language.Name})";

        public override void Deserialize(XmlElement node)
        {
            XmlAttribute languageAttribute = node.Attributes["language"];

            if (languageAttribute == null)
                throw new InvalidDataException("TypeReferenceCollection's language attribute is missing.");
            Language = Language.GetLanguage(languageAttribute.InnerText);

            foreach (XmlElement typeReferenceElement in node.GetElementsByTagName("ObjectReference"))
            {
                var reference = new ObjectReference();
                reference.Deserialize(typeReferenceElement);
                ObjectReferences.Add(reference);
            }
        }

        public override void Serialize(XmlElement node)
        {
            XmlAttribute collectionTypeAttribute = node.OwnerDocument.CreateAttribute("collectionType");
            collectionTypeAttribute.InnerText = CollectionType.LanguageTypes.ToString();
            node.Attributes.Append(collectionTypeAttribute);

            XmlAttribute languageAttribute = node.OwnerDocument.CreateAttribute("language");
            languageAttribute.InnerText = Language.AssemblyName;
            node.Attributes.Append(languageAttribute);

            foreach (ObjectReference reference in ObjectReferences)
            {
                XmlElement referenceElement = node.OwnerDocument.CreateElement("ObjectReference");
                reference.Serialize(referenceElement);
                node.AppendChild(referenceElement);
            }
            
        }
    }
}
