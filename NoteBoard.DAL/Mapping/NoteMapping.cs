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
    class NoteMapping:EntityTypeConfiguration<Note>
    {    

        public NoteMapping()
        {
            Property(a => a.Title).IsRequired().HasMaxLength(25);
            Property(a => a.Content).IsRequired().HasMaxLength(250);

            HasRequired(a => a.User)
                .WithMany(a => a.Notes)
                .HasForeignKey(a => a.UserID);

            Map(a => a.MapInheritedProperties()); // kalıtım alınana classtaki propertyler diğer tüm tablolarda kolon olarak oluşur

            HasKey(a => a.NoteID);
            Property(a => a.NoteID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
