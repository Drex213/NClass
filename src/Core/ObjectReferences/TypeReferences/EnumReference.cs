using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core.ObjectReferences.TypeReferences
{
    public class EnumReference : ObjectReference
    {
        public EnumReference()
        {
        }

        public EnumReference(string name) : base(name)
        {
        }

        public override string IconImageKey => "type-enum";
    }
}
