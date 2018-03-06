using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Blog.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CommentID, t.CommentAuthor, t.CreateDate, t.CommentContents });

            // Properties
            this.Property(t => t.CommentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CommentAuthor)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CommentContents)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Comment");
            this.Property(t => t.CommentID).HasColumnName("CommentID");
            this.Property(t => t.CommentAuthor).HasColumnName("CommentAuthor");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CommentContents).HasColumnName("CommentContents");
            this.Property(t => t.ParentCommentID).HasColumnName("ParentCommentID");
            this.Property(t => t.CommentAuthorId).HasColumnName("CommentAuthorId");
        }
    }
}
