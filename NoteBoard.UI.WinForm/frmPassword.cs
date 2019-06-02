using NoteBoard.BLL;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteBoard.UI.WinForm
{
    public partial class frmPassword : Form
    {

        public frmPassword(Password pass)
        {
            InitializeComponent();
            _pass = pass;
            _passwordController = new PasswordController();
        }
        PasswordController _passwordController;
        Password _pass;
        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            if (txtEskiSifre.Text != _pass.PasswordText)
            {
                MessageBox.Show("Lütfen eski şifrenizi doğru giriniz");
                return;
            }
            else if (txtyeniSifre.Text != txtYeniSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor");
                return;
            }

            Password newPassword = new Password();
            newPassword.PasswordText = txtyeniSifre.Text;
            newPassword.UserID = _pass.UserID;

            try
            {
                bool result = _passwordController.Add(newPassword);
                if (result)
                {
                    MessageBox.Show("Şifre güncellendi");
                }
                else
                {
                    MessageBox.Show("şifre güncellenemedi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
