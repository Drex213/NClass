using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core.ObjectReferences.TypeReferences
{
    public class BuiltInTypeReference : ObjectReference
    {
        public BuiltInTypeReference()
        {
        }

        public BuiltInTypeReference(string name)
            : base (name)
        {
        }

        public override string IconImageKey => "type-builtin";
    }
}
