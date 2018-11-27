﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core.ObjectReferences.TypeReferences
{
    public class DelegateReference : ObjectReference
    {
        public DelegateReference()
        {
        }

        public DelegateReference(TypeBase element) : base(element)
        {
        }

        public override string IconImageKey => "type-delegate";
    }
}