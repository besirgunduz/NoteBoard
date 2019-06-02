using NoteBoard.DAL.Repositories;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{
    public class NoteController
    {
        NoteDAL _noteDal;
        public NoteController()
        {
            _noteDal = new NoteDAL();
        }
        public bool Add(Note note)
        {
            note.IsActive = true;
            note.CreatedDate = DateTime.Now;
            return _noteDal.Add(note) > 0;
        }
        public bool Update(Note note)
        {
            note.ModifiedDate = DateTime.Now;
            return _noteDal.Update(note) > 0;
        }
        public bool Delete(Note note)
        {
            note.IsActive = false;
            note.ModifiedDate = DateTime.Now;
            return Update(note);
        }        
        public Note GetById(int noteID)
        {
            return _noteDal.GetByID(noteID);
        }

        public List<Note> GetNotesByUser(int userID)
        {
            return _noteDal.GetAll().Where(a => a.UserID == userID && a.IsActive).ToList();
        }


    }
}
