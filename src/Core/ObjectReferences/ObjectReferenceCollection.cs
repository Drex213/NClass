using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NClass.Core.ObjectReferences
{
    public abstract class ObjectReferenceCollection
    {
        public List<ObjectReference> ObjectReferences { get; set; } = new List<ObjectReference>();

        public abstract void Deserialize(XmlElement node);

        public enum CollectionType
        {
            LanguageTypes
        }
    }
}
