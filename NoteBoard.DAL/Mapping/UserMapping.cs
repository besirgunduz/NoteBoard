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
    class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(a => a.FirstName).IsRequired().HasMaxLength(20);
            Property(a => a.LastName).IsRequired().HasMaxLength(40);
            Property(a => a.UserName).IsRequired().HasMaxLength(16);

            HasKey(a => a.UserID);
            Property(a => a.UserID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Map(a => a.MapInheritedProperties());

            HasIndex(a => a.UserName).IsUnique();
            
        }
    }
}
