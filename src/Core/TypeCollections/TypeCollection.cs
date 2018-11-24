using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NClass.Core.TypeCollections
{
    public class TypeCollection
    {
        public Language Language { get; set; }

        public List<TypeReference> TypeReferences { get; set; } = new List<TypeReference>();

        public void Deserialize(XmlElement node)
        {
            XmlAttribute languageAttribute = node.Attributes["language"];
            if (languageAttribute == null)
                throw new InvalidDataException("TypeCollection's language attribute is missing.");
            Language = Language.GetLanguage(languageAttribute.InnerText);

            foreach (XmlElement typeReferenceElement in node.GetElementsByTagName("TypeReference"))
            {
                var reference = new TypeReference();
                reference.Deserialize(typeReferenceElement);
                TypeReferences.Add(reference);
            }
        }
    }
}
