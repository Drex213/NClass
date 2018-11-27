using NClass.Core;
using NClass.Core.ObjectReferences;
using NClass.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.GUI.ModelExplorer
{
    public class ObjectReferencesNode : ModelNode
    {
        private readonly Project project;

        public ObjectReferencesNode(Project project)
        {
            this.project = project;
            Text = Strings.ObjectReferences;
            ImageKey = "folders-stack";
            SelectedImageKey = "folders-stack";
            AddObjectReferenceNodes(project);

            project.ObjectReferenceCollectionAdded += Project_ObjectReferenceCollectionAdded;
            project.ObjectReferenceCollectionRemoved += Project_ObjectReferenceCollectionRemoved;
        }

        private void AddObjectReferenceNodes(Project project)
        {
            foreach (var collection in project.ObjectReferenceCollections)
            {
                AddObjectReferenceCollectionNode(collection);
            }
        }

        private void AddObjectReferenceCollectionNode(ObjectReferenceCollection collection)
        {
            if (collection is TypeReferenceCollection)
            {
                var node = new TypeReferenceCollectionNode(collection, project);
                Nodes.Add(node);
            }
        }

        private void RemoveObjectReferenceCollectionNode(ObjectReferenceCollection collection)
        {
            foreach (ObjectReferenceCollectionNode node in Nodes)
            {
                if (node.ObjectReferenceCollection == collection)
                {
                    Nodes.Remove(node);
                    break;
                }
            }
        }

        private void Project_ObjectReferenceCollectionAdded(object sender, ObjectReferenceEventArgs e)
        {
            AddObjectReferenceCollectionNode(e.Collection);
        }

        private void Project_ObjectReferenceCollectionRemoved(object sender, ObjectReferenceEventArgs e)
        {
            RemoveObjectReferenceCollectionNode(e.Collection);
        }
    }
}
