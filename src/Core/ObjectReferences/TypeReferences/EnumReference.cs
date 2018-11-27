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

        public EnumReference(TypeBase element) : base(element)
        {
        }

        public override string IconImageKey => "type-enum";
    }
}
