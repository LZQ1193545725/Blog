using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Blog.Models.Mapping;
using System.Linq.Expressions;
using System;

namespace Blog.Models
{
    public partial class BlogContext : DbContext
    {
        static BlogContext()
        {
            Database.SetInitializer<BlogContext>(null);
        }

        public BlogContext()
            : base("Name=BlogContext")
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<LearningNote> LearningNotes { get; set; }
        public DbSet<VisitorColloction> VisitorColloction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new LearningNoteMap());
            modelBuilder.Configurations.Add(new VisitorColloctionMap());
        }


    }
}
