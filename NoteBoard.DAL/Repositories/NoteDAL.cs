using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Repositories
{
    public class NoteDAL
    {
        NoteBoardDbContext _db;
        public NoteDAL()
        {
            _db = new NoteBoardDbContext();
        }

        public int Add(Note note)
        {
            _db.Entry(note).State = EntityState.Added;
            return _db.SaveChanges();
        }

        public int Update(Note note)
        {
            _db.Entry(note).State = EntityState.Modified;
            return _db.SaveChanges();
        }

        public int Delete(Note note)
        {
            _db.Entry(note).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public Note GetByID(int noteID)
        {
            return _db.Notes.FirstOrDefault(a => a.NoteID == noteID);

        }

        public List<Note> GetAll()
        {
            return _db.Notes.ToList();
        }


    }
}
