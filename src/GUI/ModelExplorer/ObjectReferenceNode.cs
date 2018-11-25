using NClass.Core.ObjectReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.GUI.ModelExplorer
{
    public class ObjectReferenceNode : ModelNode
    {
        public ObjectReferenceNode(ObjectReference objectReference)
        {
            Text = objectReference.Name;
            ImageKey = "type-builtin";
            SelectedImageKey = "type-builtin";
            ObjectReference = objectReference;
        }

        public ObjectReference ObjectReference { get; }
    }
}
