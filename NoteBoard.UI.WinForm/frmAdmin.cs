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
    public partial class frmAdmin : Form
    {
        UserController _userController;
        public frmAdmin()
        {
            InitializeComponent();
            _userController = new UserController();
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            FillUsers();
        }

        public void FillUsers()
        {
            lvUsers.Items.Clear();
            List<User> allUsers = _userController.GetAll();
            ListViewItem lvi;

            foreach (User item in allUsers)
            {
                lvi = new ListViewItem(item.FirstName);
                lvi.SubItems.Add(item.LastName);
                lvi.SubItems.Add(item.UserName);
                lvi.SubItems.Add(item.IsActive ? "Aktif" : "Pasif");
                lvi.Tag = item;
                lvUsers.Items.Add(lvi);
            }          
        }

        private void lvUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selected = lvUsers.SelectedItems[0];
            User selectedUser = selected.Tag as User;
            if(!selectedUser.IsActive)
            {
                DialogResult result = MessageBox.Show("Bu kullanıcıyı onaylıyor musunuz ?","Onay",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                    selectedUser.IsActive = true;
                    _userController.Update(selectedUser);
                    FillUsers();
                }
                
            }
        }

        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
           this.Owner.Show();
            (this.Owner as frmLogin).SorunCozenMetod();
        }
    }
}
