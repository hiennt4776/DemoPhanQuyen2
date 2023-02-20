using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPhanQuyen2
{
    public partial class Form3 : Form
    {
        List<string> checkedNodesString = new List<string>();
        private static PermissionDetailADO permissionDetailADO = new PermissionDetailADO();

        


        public Form3(int id, string username, string fullname)
        {
            InitializeComponent();
         
            toolStripStatusLabelId.Text = "ID: " + id.ToString();
            toolStripStatusLabelUsername.Text = "Username: " + username;
            toolStripStatusLabelFullname.Text = "Fullname: " + fullname;
            LoadMenuItemOfPermission(id);



        }

        private void HideAllSubMenuItems(ToolStripDropDownItem menuItem)
        {
            foreach (ToolStripItem subMenuItem in menuItem.DropDownItems)
            {
                if (subMenuItem is ToolStripDropDownItem)
                {
                    HideAllSubMenuItems((ToolStripDropDownItem)subMenuItem);
                }
                subMenuItem.Visible = false;
            }
        }
        private void HideAllMenuItems(MenuStrip menuStrip)
        {
            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
            {
                menuItem.Visible = false;
                HideAllSubMenuItems(menuItem);
            }
        }

        private void TreeViewString(TreeNode currentNode, List<String> checkedNodes)
        {
            if (currentNode.Checked)
            {
                //MessageBox.Show(currentNode.Name);
                checkedNodes.Add(currentNode.Name);
            }

            foreach (TreeNode node in currentNode.Nodes)
            {
                TreeViewString(node, checkedNodes);
            }
        }

        private void ShowSubMenuItems(MenuStrip menuStrip, List<String> checkedNodes)
        {
            foreach (ToolStripMenuItem menuItem in menuStrip.Items)
            {
                if (checkedNodes.Contains(menuItem.Name))
                {
                    menuItem.Visible = true;
                }

                ShowSubMenuItems(menuItem, checkedNodes);
            }
        }

        private void ShowSubMenuItems(ToolStripDropDownItem menuItem, List<String> checkedNodes)
        {
            foreach (ToolStripItem subMenuItem in menuItem.DropDownItems)
            {
                if (subMenuItem is ToolStripDropDownItem)
                {
                    ShowSubMenuItems((ToolStripDropDownItem)subMenuItem, checkedNodes);
                }
                if (checkedNodes.Contains(subMenuItem.Name))
                {
                    subMenuItem.Visible = true;
                }

            }
        }

        private void LoadMenuItemOfPermission(int id)
        {
            HideAllMenuItems(menuStrip1);
            checkedNodesString.Clear();
            DataTable persmissionUserDataTable = permissionDetailADO.LoadUserPermission(id);
            foreach(DataRow item in persmissionUserDataTable.Rows)
            {
                checkedNodesString.Add(item["nameKeyPermission"].ToString());
            }
            //foreach (TreeNode node in tvShowMenu.Nodes)
            //{
            //    TreeViewString(node, checkedNodesString);
            //}

            ShowSubMenuItems(menuStrip1, checkedNodesString);
        }

    

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new instance of the MDI child template form
            frmUserPermissions chForm = new frmUserPermissions();

            //Set parent form for the child window 
            chForm.MdiParent = this;
            chForm.WindowState = FormWindowState.Maximized;

            //Display the child window
            chForm.Show();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new instance of the MDI child template form
            frmCreateUser chForm = new frmCreateUser();

            //Set parent form for the child window 
            chForm.MdiParent = this;
            chForm.WindowState = FormWindowState.Maximized;

            //Display the child window
            chForm.Show();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void subItem17ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
           

        }
    }
}
