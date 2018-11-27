using NClass.Core.ObjectReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core
{
    public delegate void ObjectReferenceEventHandler(object sender, ObjectReferenceEventArgs e);

    public class ObjectReferenceEventArgs
    {
        public ObjectReferenceEventArgs(ObjectReferenceCollection collection, ObjectReference reference = null)
        {
            Collection = collection;
            Reference = reference;
        }

        public ObjectReferenceCollection Collection { get; }

        public ObjectReference Reference { get; }
    }
}
