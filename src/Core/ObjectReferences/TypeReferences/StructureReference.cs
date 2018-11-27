using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core.ObjectReferences.TypeReferences
{
    public class StructureReference : ObjectReference
    {
        public StructureReference()
        {
        }

        public StructureReference(TypeBase element) : base(element)
        {
        }

        public override string IconImageKey => "type-structure";
    }
}
