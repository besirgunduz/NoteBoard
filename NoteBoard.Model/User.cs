using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.Model
{
    public class User:BaseEntity
    {
        public User()
        {
            Passwords = new HashSet<Password>();
            Notes = new HashSet<Note>();
        }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }

        //navigation property
        public virtual ICollection<Password> Passwords { get; set; }
        public virtual ICollection<Note> Notes { get; set; }


    }
}
