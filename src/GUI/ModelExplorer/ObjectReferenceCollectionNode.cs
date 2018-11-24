using NClass.Core.ObjectReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.GUI.ModelExplorer
{
    public abstract class ObjectReferenceCollectionNode : ModelNode
    {
        public ObjectReferenceCollection ObjectReferenceCollection { get; set; }
    }
}
