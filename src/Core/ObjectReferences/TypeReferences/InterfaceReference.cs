using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core.ObjectReferences.TypeReferences
{
    public class InterfaceReference : ObjectReference
    {
        public InterfaceReference()
        {
        }

        public InterfaceReference(string name) : base(name)
        {
        }

        public override string IconImageKey => "type-interface";
    }
}
