using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileExplorer_TreeView;

namespace DicomViewer
{
    public partial class PickStudiesDialog : Form
    {
        FileExplorer fe = new FileExplorer();
        public PickStudiesDialog()
        {
            InitializeComponent();
            fe.CreateTree(this.treeViewFolders);
        }

        private void treeViewFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "")
            {
                TreeNode node = fe.EnumerateDirectory(e.Node);
            } 
        }
    }
}
