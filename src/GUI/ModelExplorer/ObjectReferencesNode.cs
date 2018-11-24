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
        public ObjectReferencesNode(Project project)
        {
            Text = Strings.ObjectReferences;
            ImageKey = "folders-stack";
            SelectedImageKey = "folders-stack";
            AddObjectReferenceNodes(project);
        }

        private void AddObjectReferenceNodes(Project project)
        {
            foreach (var collection in project.ObjectReferenceCollections)
            {
                AddObjectRefereneceCollectionNode(collection);
            }
        }

        private void AddObjectRefereneceCollectionNode(ObjectReferenceCollection collection)
        {
            if (collection is TypeReferenceCollection)
            {
                var node = new TypeReferenceCollectionNode(collection);
                Nodes.Add(node);
            }
        }
    }
}
