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

        public InterfaceReference(TypeBase element) : base(element)
        {
        }

        public override string IconImageKey => "type-interface";
    }
}
