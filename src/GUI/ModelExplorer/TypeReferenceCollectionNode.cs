using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NClass.Core;
using NClass.Core.ObjectReferences;

namespace NClass.GUI.ModelExplorer
{
    public class TypeReferenceCollectionNode : ObjectReferenceCollectionNode
    {
        public TypeReferenceCollectionNode(ObjectReferenceCollection collection, Project project)
        {
            Text = collection.Name;
            ImageKey = "folder";
            SelectedImageKey = "folder";
            ObjectReferenceCollection = collection;
            AddObjectNodes(collection);

            project.ObjectReferenceAdded += Project_ObjectReferenceAdded;
            project.ObjectReferenceRemoved += Project_ObjectReferenceRemoved;
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

        private void RemoveObjectNode(ObjectReference objectReference)
        {
            foreach (ObjectReferenceNode node in Nodes)
            {
                if (node.ObjectReference == objectReference)
                {
                    Nodes.Remove(node);
                    break;
                }
            }
        }

        private void Project_ObjectReferenceAdded(object sender, ObjectReferenceEventArgs e)
        {
            if (e.Collection != ObjectReferenceCollection)
                return;

            AddObjectNode(e.Reference);
        }

        private void Project_ObjectReferenceRemoved(object sender, ObjectReferenceEventArgs e)
        {
            if (e.Collection != ObjectReferenceCollection)
                return;

            RemoveObjectNode(e.Reference);
        }
    }
}
