using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Plays.tv.Database;
using Plays.tv_App.Controllers;

namespace Plays.tv_App
{
    public partial class Login : Form
    {
        private AccountRepository acc;
        public Login()
        {
            acc = new AccountRepository(new AccountSQLiteContext());
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            AccountRepository.LoggedUser = acc.Login(tbUsername.Text, tbPassword.Text);
            Account activeUser = AccountRepository.LoggedUser;
            try
            {
                //Check if their is already a active user
                if (activeUser != null)
                {
                    //Check for user or admin
                    if (activeUser is User)
                    {
                        MessageBox.Show("Succes");
                        MainForm newForm = new MainForm();
                        newForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        AdminForm newAdminForm = new AdminForm();
                        newAdminForm.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
