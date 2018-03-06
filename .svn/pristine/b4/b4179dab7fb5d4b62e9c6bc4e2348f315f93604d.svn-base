using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Blog.Models.Mapping
{
    public class LearningNoteMap : EntityTypeConfiguration<LearningNote>
    {
        public LearningNoteMap()
        {
            // Primary Key
            this.HasKey(t => t.NotesID);

            // Properties
            this.Property(t => t.NotesTitle)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NotesAuthor)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("LearningNotes");
            this.Property(t => t.NotesID).HasColumnName("NotesID");
            this.Property(t => t.NotesTitle).HasColumnName("NotesTitle");
            this.Property(t => t.NotesAuthor).HasColumnName("NotesAuthor");
            this.Property(t => t.NotesType).HasColumnName("NotesType");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.ModifyDate).HasColumnName("ModifyDate");
            this.Property(t => t.NotesContents).HasColumnName("NotesContents");
            this.Property(t => t.NotesReadNum).HasColumnName("NotesReadNum");
            this.Property(t => t.CommentID).HasColumnName("CommentID");
        }
    }
}
