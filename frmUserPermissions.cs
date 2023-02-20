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
    public partial class frmUserPermissions : Form
    {
        private UserADO userADO = new UserADO();
        public frmUserPermissions()
        {
            InitializeComponent();
        }
        //Load User
        private void LoadUser()
        {
            DataTable usersTable = userADO.selectAllUser();

            lvwUser.Items.Clear();

            foreach (DataRow row in usersTable.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(row[0].ToString());
                listViewItem.SubItems.Add(row[1].ToString());
                listViewItem.SubItems.Add(row[3].ToString());
                lvwUser.Items.Add(listViewItem);
            }

        }
        private void frmUserPermissions_Load(object sender, EventArgs e)
        {
            LoadUser();
        }
        //Gọi event khi click chuột phải hiện ra contextmenustrip và lấy item được chọn
        private void lvwUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem clickedItem = lvwUser.GetItemAt(e.X, e.Y);
                if (clickedItem != null)
                {
                    contextMenuStrip1.Show(lvwUser, e.Location);
                    
                }
            }
        }
        //Lấy item đã chọn, hiện form PermissionDetail sau event Click mouse
        private void detailMenuItem_Click(object sender, EventArgs e)
        {
            
            foreach (ListViewItem selectedItem in lvwUser.SelectedItems)
            {
                // Get the data from the selected item and pass it to the detail form
                int id = int.Parse(selectedItem.SubItems[0].Text);
                PermissionsDetail frmPermissionsDetail = new PermissionsDetail(id);
                frmPermissionsDetail.Show();
            }
        }

      
    }
}
