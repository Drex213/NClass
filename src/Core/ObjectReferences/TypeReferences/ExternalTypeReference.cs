using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core.ObjectReferences.TypeReferences
{
    public class ExternalTypeReference : ObjectReference
    {
        public ExternalTypeReference()
        {
        }

        public ExternalTypeReference(string name)
            : base(name)
        {
        }

        public override string IconImageKey => "type-external";
    }
}
