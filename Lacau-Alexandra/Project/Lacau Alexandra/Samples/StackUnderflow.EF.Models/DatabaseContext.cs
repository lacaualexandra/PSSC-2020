using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.EFCore.DSL;
using Access.Primitives.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.EF.Models;

namespace StackUnderflow.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public static Port<DatabaseContext> Factory(IServiceProvider sp)
            => from dbContext in DbContextDSL<DatabaseContext>.CreateDbContext(sp)
               select dbContext;

        public DbSet<Reply> Replies { get; set; }
        public DbSet<Post> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ACCESS-1303SF2\\SQL2017;Database=StackUnderflow;Integrated Security=true;");
            }
        }
    }
}
