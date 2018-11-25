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
            Name = nameof(ObjectReferencesNode);
            Text = Strings.ObjectReferences;
            ImageKey = "folders-stack";
            SelectedImageKey = "folders-stack";
            AddObjectReferenceNodes(project);
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
                var node = new TypeReferenceCollectionNode(collection);
                Nodes.Add(node);
            }
        }

        public void Refresh()
        {
            RefreshRemovedCollections();

            foreach (var collection in project.ObjectReferenceCollections)
            {
                RefreshCollection(collection);
            }

            RefreshAddedCollections();
        }

        private void RefreshAddedCollections()
        {
            var previouslyExistedNodeNames = new HashSet<string>(Nodes.Cast<ObjectReferenceCollectionNode>().Select(c => c.Text));
            foreach (var collection in project.ObjectReferenceCollections)
            {
                if (!previouslyExistedNodeNames.Contains(collection.Name))
                    AddObjectReferenceCollectionNode(collection);
            }
        }

        private void RefreshRemovedCollections()
        {
            var stillExistingCollectionNames = new HashSet<string>(project.ObjectReferenceCollections.Select(c => c.Name));
            for (int i = Nodes.Count - 1; i >= 0; i--)
            {
                if (!stillExistingCollectionNames.Contains(Nodes[i].Text))
                    Nodes.RemoveAt(i);
            }
        }

        private void RefreshCollection(ObjectReferenceCollection collection)
        {
            var collectionNodes = Nodes.Cast<ObjectReferenceCollectionNode>().ToDictionary(n => n.Text, n => n);
            if (!collectionNodes.ContainsKey(collection.Name))
                return;

            var collectionNode = collectionNodes[collection.Name];
            var referenceNodes = collectionNode.Nodes.Cast<ObjectReferenceNode>().ToDictionary(n => n.Text, n => n);
            var existingReferenceNames = new HashSet<string>(collection.ObjectReferences.Select(r => r.Name));

            for (int i = collectionNode.Nodes.Count - 1; i >= 0; i--)
            {
                if (!existingReferenceNames.Contains(collectionNode.Nodes[i].Text))
                    collectionNode.Nodes.RemoveAt(i);
            }

            foreach (var reference in collection.ObjectReferences)
            {
                if (!referenceNodes.ContainsKey(reference.Name))
                    collectionNode.Nodes.Add(new ObjectReferenceNode(reference));
            }
        }
    }
}
