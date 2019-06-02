using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.DAL.Mapping
{
    class PasswordMapping:EntityTypeConfiguration<Password>
    {
        public PasswordMapping()
        {
            Property(a => a.PasswordText).IsRequired().HasMaxLength(16);

            HasRequired(a => a.User)
                .WithMany(a => a.Passwords)
                .HasForeignKey(a => a.UserID);

            Map(a => a.MapInheritedProperties());

            HasKey(a => a.PasswordID);
            Property(a => a.PasswordID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
