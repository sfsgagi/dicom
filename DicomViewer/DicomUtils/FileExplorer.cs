using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using log4net;




namespace FileExplorer_TreeView
{
    /* Class  :FileExplorer
     * Author : Chandana Subasinghe
     * Date   : 10/03/2006
     * Discription : This class use to create the tree view and load 
     *               directories and files in to the tree
     *          
     */
    class FileExplorer
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FileExplorer));
        public FileExplorer()
        {

        }

        /* Method :CreateTree
         * Author : Chandana Subasinghe
         * Date   : 10/03/2006
         * Discription : This is use to creat and build the tree
         *          
         */

        public bool CreateTree(TreeView treeView)
        {
            bool returnValue = false;
                 
            try
            {
                // Create Desktop
                TreeNode desktop = new TreeNode();
                desktop.Text = "Desktop";
                desktop.Tag = "Desktop";
                desktop.Nodes.Add("");
                treeView.Nodes.Add(desktop);
                // Get driveInfo
                foreach (DriveInfo drv in DriveInfo.GetDrives())
                {
                    
                    TreeNode fChild = new TreeNode();
                    if (drv.DriveType == DriveType.CDRom)
                    {
                        fChild.ImageIndex = 1;
                        fChild.SelectedImageIndex = 1;
                    }
                    else if (drv.DriveType == DriveType.Fixed)
                    {
                        fChild.ImageIndex = 0;
                        fChild.SelectedImageIndex = 0;
                    }
                    fChild.Text = drv.Name;
                    fChild.Nodes.Add("");
                    treeView.Nodes.Add(fChild);
                    returnValue = true;
                }

            }
            catch (Exception ex)
            {
                returnValue = false;
                log.Error("Error while creating tree!");
                log.Error(ex.StackTrace);
            }
            return returnValue;
            
        }

        public TreeNode EnumerateDirectory(TreeNode parentNode)
        {
          
            try
            {
                DirectoryInfo rootDir;

                // To fill Desktop
                Char [] arr={'\\'};
                string [] nameList=parentNode.FullPath.Split(arr);
                string path = "";

                if (nameList.GetValue(0).ToString() == "Desktop")
                {

                    path = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\";

                    for (int i = 1; i < nameList.Length; i++)
                    {
                        path = path + nameList[i] + "\\";
                    }

                    rootDir = new DirectoryInfo(path);
                }
             // for other Directories
                else
                {
                   
                    rootDir = new DirectoryInfo(parentNode.FullPath + "\\");
                }
                
                parentNode.Nodes[0].Remove();
                foreach (DirectoryInfo dir in rootDir.GetDirectories())
                {
                    
                    TreeNode node = new TreeNode();
                    node.Text = dir.Name;
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);
                }
                //Fill files
                foreach (FileInfo file in rootDir.GetFiles())
                {
                    TreeNode node = new TreeNode();
                    node.Text = file.Name;
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;
                    parentNode.Nodes.Add(node);
                }



            }

            catch (Exception ex)
            {
                log.Error("Error while Enumerating directory!");
                log.Error(ex.StackTrace);
            }
           
            return parentNode;
        }
    }
}
