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
    public partial class frmMain : Form
    {
        User _user;
        NoteController _noteController;
        PasswordController _passwordController;
        public frmMain(User user)
        {
            InitializeComponent();
            _user = user;
            _noteController = new NoteController();
            _passwordController = new PasswordController();
        }
        void FillNotes()
        {
            List<Note> notes = _noteController.GetNotesByUser(_user.UserID);
            lstNotes.DisplayMember = "Title";
            lstNotes.ValueMember = "NoteID";
            lstNotes.DataSource = notes;
            lstNotes.SelectedIndex = -1;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FillNotes();
        }
        
        void UpdateNote()
        {
            int noteID = (int)lstNotes.SelectedValue;
            Note selected = _noteController.GetById(noteID);

            selected.Title = txtTitle.Text;
            selected.Content = txtContent.Text;

            bool result = _noteController.Update(selected);
            if(result)
            {
                MessageBox.Show("Güncellendi");
                txtTitle.Text = "";
                txtContent.Clear();
                FillNotes();
            }
            else
            {
                MessageBox.Show("Güncellenmedi");
            }
        }

        private void AddNote()
        {
            Note note = new Note();
            note.Title = txtTitle.Text;
            note.Content = txtContent.Text;
            note.UserID = _user.UserID;

            bool result = _noteController.Add(note);
            if(result)
            {
                MessageBox.Show("Not eklenmiştir.");
                txtTitle.Clear();
                txtContent.Clear();
                FillNotes();
            }
            else
            {
                MessageBox.Show("Not eklenemedi");
            }
        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstNotes.SelectedIndex<0)
            {
                return;
            }

            int noteID = (int)lstNotes.SelectedValue;
            Note selected = _noteController.GetById(noteID);
            txtTitle.Text = selected.Title;
            txtContent.Text = selected.Content;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(lstNotes.SelectedIndex<0)
            {
                MessageBox.Show("Note şeç");
                return;
            }

            int noteID = (int)lstNotes.SelectedValue;
            Note selected = _noteController.GetById(noteID);
            bool result = _noteController.Delete(selected);
            if(result)
            {
                MessageBox.Show("Not başarıyla silindi");
                FillNotes();
            }
            else
            {
                MessageBox.Show("Not silme işlemi gerçekleşmedi");
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(lstNotes.SelectedIndex<0)
            {
                AddNote();
            }
            else
            {
                UpdateNote();
            }
        }

        private void linkLblSifre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Password password = _passwordController.GetActivePassword(_user.UserID);
            frmPassword frm = new frmPassword(password);
            frm.Owner = this.Owner;
            frm.Show();
            this.Close();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
