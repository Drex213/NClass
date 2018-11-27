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
    public abstract class ObjectReferenceCollection
    {
        public List<ObjectReference> ObjectReferences { get; set; } = new List<ObjectReference>();

        public abstract string Name { get; }

        public abstract void Deserialize(XmlElement node);

        public abstract void Serialize(XmlElement node);

        public enum CollectionType
        {
            LanguageTypes
        }
    }
}
