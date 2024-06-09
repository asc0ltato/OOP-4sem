using System;
using System.IO;
using System.Windows.Forms;

namespace _19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DriveInfo[] drives = DriveInfo.GetDrives();
            TreeNode main = new TreeNode("Мой компьютер");

            foreach (DriveInfo drive in drives)
            {
                TreeNode d = new TreeNode(drive.Name);
                main.Nodes.Add(d);
                DirectoryInfo[] dirs = drive.RootDirectory.GetDirectories();

                foreach (DirectoryInfo dir in dirs)
                {
                    TreeNode f = new TreeNode(dir.Name);
                    d.Nodes.Add(f);
                    FileInfo[] files = drive.RootDirectory.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        TreeNode fl = new TreeNode(file.Name);
                        f.Nodes.Add(fl);
                    }
                }
            }
            treeView1.Nodes.Add(main);
        }
    }
}
