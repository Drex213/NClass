using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NClass.Core.ObjectReferences;

namespace NClass.GUI.ModelExplorer
{
    public class TypeReferenceCollectionNode : ObjectReferenceCollectionNode
    {
        public TypeReferenceCollectionNode(ObjectReferenceCollection collection)
        {
            Text = collection.Name;
            ImageKey = "folder";
            SelectedImageKey = "folder";
            ObjectReferenceCollection = collection;
            AddObjectNodes(collection);
        }

        private void AddObjectNodes(ObjectReferenceCollection collection)
        {
            foreach (var objectReference in collection.ObjectReferences)
            {
                AddObjectNode(objectReference);
            }
        }

        private void AddObjectNode(ObjectReference objectReference)
        {
            var node = new ObjectReferenceNode(objectReference);
            Nodes.Add(node);
        }
    }
}
