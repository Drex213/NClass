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
    }
}
