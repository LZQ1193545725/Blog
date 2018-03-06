using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Blog.Models.Mapping
{
    public class VisitorColloctionMap:EntityTypeConfiguration<VisitorColloction>
    {
        public VisitorColloctionMap()
        {
            // Primary Key
            this.HasKey(t =>t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("VisitorColloction");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.VisitorID).HasColumnName("VisitorID");
            this.Property(t => t.VisitorIP).HasColumnName("VisitorIP");
            this.Property(t => t.VisitorName).HasColumnName("VisitorName");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.LoginDate).HasColumnName("LoginDate");
            this.Property(t => t.IsFirst).HasColumnName("IsFirst");
        }
    }
}
