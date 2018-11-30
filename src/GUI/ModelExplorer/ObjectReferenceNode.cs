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
            objectReference.Removed += ObjectReference_Removed;
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

            var success = referenceNode.ObjectReference.TryDelete();
            if (success)
                return;

            DialogResult result = MessageBox.Show(
                    Strings.CannotDeleteObjectReference, Strings.Warning,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ObjectReference_Modified(object sender, EventArgs e)
        {
            var reference = (ObjectReference)sender;
            Text = reference.Name;
        }

        private void ObjectReference_Removed(object sender, EventArgs e)
        {
            var reference = (ObjectReference)sender;
            reference.Modified -= ObjectReference_Modified;
            reference.Removed -= ObjectReference_Removed;

            Parent.Nodes.Remove(this);
        }
    }
}
