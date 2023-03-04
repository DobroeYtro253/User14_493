using OOOSportProduct.Classes;
using OOOSportProduct.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOOSportProduct
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        User user;
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (Helper.DbContext.Users.Where(x => x.userLogin == textBoxLogin.Text).FirstOrDefault() == null)
            {
                user = default;
            }
            else
            {
                user = Helper.DbContext.Users.Where(x => x.userLogin == textBoxLogin.Text).FirstOrDefault();
            }
           
            if (user == default)
            {
                MessageBox.Show("Такого пользователя не существует");
                return;
            }
            else
            {
                if (user.userPassword == textBoxPassword.Text)
                {
                    MessageBox.Show("Авторизация успешна \r Вы вошли под ролью: " + Helper.DbContext.Roles.Where(x => x.roleID == user.userRoleId).FirstOrDefault().roleName );
                    Catalog ca = new Catalog();
                    this.Hide();
                    ca.ShowDialog();
                    this.Show();
                }
                else { MessageBox.Show("Введите правильный пароль"); }
            }
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Авторизация успешна \r Вы вошли под ролью: Гость");
            Catalog ca = new Catalog();
            this.Hide();
            ca.ShowDialog();
            this.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение закрывается");
            this.Close();
        }
    }
}
