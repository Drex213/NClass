using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core.ObjectReferences.TypeReferences
{
    public class ClassReference : ObjectReference
    {
        public ClassReference()
        {
        }

        public ClassReference(string name) 
            : base(name)
        {
        }

        public override string IconImageKey => "type-class";
    }
}
