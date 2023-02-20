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
    public partial class Login : Form
    {
        private UserADO userADO = new UserADO();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user = userADO.CheckLoginUser(txtUsername.Text, txtPassword.Text);

            if (user != null)
            {
                Form3 form3 = new Form3(user.Id, user.Username, user.Fullname);
                form3.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
