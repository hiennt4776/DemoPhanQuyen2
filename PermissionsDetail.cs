using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPhanQuyen2
{
    public partial class PermissionsDetail : Form
    {

        private static PermissionDetailADO permissionDetailADO = new PermissionDetailADO();
        DataTable persmissionDataTable = permissionDetailADO.LoadMenuItem();
      
        public PermissionsDetail(int id)
        {
            InitializeComponent();
            lblId.Text = id.ToString();
            LoadItems();
            LoadUserPermission(id);
        }


        //Load các quyền trong bảng persmission đưa vào treeView tvPermissions
        public void LoadItems()
        {
            foreach (DataRow menuItem in persmissionDataTable.Rows)
            {
                AddMenuItemToTreeView(menuItem, null);      
            }          
        }

        //từ list => checked vào treeView tvPermissions
        private void LoadPermissionNodes(TreeNodeCollection nodes, List<String> UserPermission)
        {
            foreach (TreeNode node in nodes)
            {
                // Set the Checked property of the node to true
                if (UserPermission.Contains(node.Name))
                {
                    node.Checked = true;
                }
               

                // Recursively check all child nodes
                if (node.Nodes.Count > 0)
                {
                    LoadPermissionNodes(node.Nodes, UserPermission);
                }
            }
        }

        // Call the CheckAllNodes function with the top-level nodes of the TreeView

        //Load các quyền đã phân trong bảng UserPermission đưa vào list, từ list => checked vào treeView tvPermissions
        public void LoadUserPermission(int id)
        {
            DataTable persmissionUserDataTable = permissionDetailADO.LoadUserPermission(id);
            List<String> UserPermission = new List<string>();
            if (persmissionUserDataTable.Rows.Count > 0)
            {
                foreach (DataRow subItem in persmissionUserDataTable.Rows)
                {
                    UserPermission.Add(subItem["nameKeyPermission"].ToString());
                }
            }
            LoadPermissionNodes(tvPermissions.Nodes, UserPermission);

        }
     
        // Đưa từng hàng trong bảng vào trong treeview 
        private void AddMenuItemToTreeView(DataRow menuItem, TreeNode parentNode)
        {
          
            TreeNode newNode = new TreeNode();
            newNode.Name = menuItem["nameKey"].ToString();
            newNode.Text = menuItem["nameText"].ToString();
            DataTable subItemTable = permissionDetailADO.LoadSubItem(newNode.Name);       
            if (subItemTable.Rows.Count > 0)
            {              
                foreach (DataRow subItem in subItemTable.Rows)
                {
                    AddMenuItemToTreeView(subItem, newNode);
                }
            }           
            if (parentNode != null)
            {
                parentNode.Nodes.Add(newNode);
            }        
            else
            {
                tvPermissions.Nodes.Add(newNode);
            }
        }

        //Mặc định khi check parent thì tất cả child đều checked trên treeview
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        //Mặc định khi check child thì tất cả parent của child đó đều checked trên treeview
        private void SelectParents(TreeNode node, Boolean isChecked)
        {
            var parent = node.Parent;

            if (parent == null)
                return;

            //if (!isChecked && HasCheckedNode(parent))
            //    return;
            if (!isChecked)
               return;

                parent.Checked = isChecked;
            SelectParents(parent, isChecked);
        }

        //private bool HasCheckedNode(TreeNode node)
        //{
        //    return node.Nodes.Cast<TreeNode>().Any(n => n.Checked);
        //}

        //gọi event sau khi check
        private void tvPermissions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
            SelectParents(e.Node, e.Node.Checked);
        }
        //lấy tất cả nodes đã check đưa vào list string
        private void GetCheckedNodes(TreeNodeCollection nodes, List<string> checkedNodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Check if the node is checked
                if (node.Checked)
                {
                    // Add the node's text to the list of checked nodes
                    checkedNodes.Add(node.Name);
                }

                // Recursively check all child nodes
                if (node.Nodes.Count > 0)
                {
                    GetCheckedNodes(node.Nodes, checkedNodes);
                }
            }
        }


        // Create a list to hold the checked nodes
       

        // Call the GetCheckedNodes function with the top-level nodes of the TreeView
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> checkedPermissionList = new List<string>();
            GetCheckedNodes(tvPermissions.Nodes, checkedPermissionList);
            permissionDetailADO.DeleteUserPermission(int.Parse(lblId.Text));
            permissionDetailADO.InsertUserPermission(int.Parse(lblId.Text), checkedPermissionList);    
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  