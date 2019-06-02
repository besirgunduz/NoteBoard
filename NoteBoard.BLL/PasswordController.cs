using NoteBoard.DAL.Repositories;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{

    public class PasswordController
    {
        PasswordDAL _passwordDAL;
        public PasswordController()
        {
            _passwordDAL = new PasswordDAL();
        }
        public bool Delete(Password pass)
        {
            pass.IsActive = false;
            pass.ModifiedDate = DateTime.Now;
            return _passwordDAL.Update(pass) > 0;
        }
        public bool Add(Password pass)
        {   List<Password> passwords = GetAllByUsers(pass.UserID);
            passwords = passwords.OrderByDescending(a => a.CreatedDate).Take(3).ToList();
            if (passwords.FirstOrDefault(a => a.PasswordText == pass.PasswordText) != null)
            {
                throw new Exception("Son üç şifreden farklı olmalıdır.");
            }
            Delete(passwords.First());
            pass.IsActive = true;
            pass.CreatedDate = DateTime.Now;
            return _passwordDAL.Add(pass) > 0;
        }
        List<Password> GetAllByUsers(int userID)
        {
            return _passwordDAL.GetAll().Where(a => a.UserID == userID).ToList();
        }
        public Password GetActivePassword(int userID)
        {
            List<Password> allPasswords = GetAllByUsers(userID);
            return allPasswords.Where(a => a.IsActive).SingleOrDefault();
        }






    }
}
