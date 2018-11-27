using NClass.Core.ObjectReferences;
using NClass.GUI.Properties;
using NClass.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NClass.GUI.ModelExplorer
{
    public class ObjectReferenceNode : ModelNode
    {
        static ContextMenuStrip contextMenu = new ContextMenuStrip();

        static ObjectReferenceNode()
        {
            contextMenu.Items.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem(Strings.MenuDeleteProjectItem, Resources.Delete,
                    DeleteReference_Click)
            });
        }

        public ObjectReferenceNode(ObjectReference objectReference)
        {
            Text = objectReference.Name;
            ImageKey = objectReference.IconImageKey;
            SelectedImageKey = objectReference.IconImageKey;
            ObjectReference = objectReference;
            objectReference.Modified += ObjectReference_Modified;
        }

        public ObjectReference ObjectReference { get; }

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                contextMenu.Tag = this;
                return contextMenu;
            }
            set
            {
                base.ContextMenuStrip = value;
            }
        }

        private static void DeleteReference_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripItem)sender;
            var referenceNode = (ObjectReferenceNode)menuItem.Owner.Tag;
            var collectionNode = (ObjectReferenceCollectionNode)referenceNode.Parent;
            var objectsNode = (ObjectReferencesNode)collectionNode.Parent;
            var projectNode = (ProjectNode)objectsNode.Parent;
            projectNode.Project.Remove(referenceNode.ObjectReference, collectionNode.ObjectReferenceCollection);
        }

        private void ObjectReference_Modified(object sender, EventArgs e)
        {
            var reference = (ObjectReference)sender;
            Text = reference.Name;
        }
    }
}
