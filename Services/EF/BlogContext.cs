using Microsoft.EntityFrameworkCore;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EF
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> dbOptions) : base(dbOptions) { }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(b =>
            {
                b.Property(x => x.Title).HasMaxLength(200);
                b.HasMany(x => x.Comments).WithOne().HasForeignKey(c => c.BlogId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
