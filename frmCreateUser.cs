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
    public partial class frmCreateUser : Form
    {
        public frmCreateUser()
        {
            InitializeComponent();
        }
        private UserADO userADO = new UserADO();
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            string Fullname = txtFullname.Text;

            userADO.insertUser(Username, Password,Fullname);
            //this.Close();
        }
    }
}
