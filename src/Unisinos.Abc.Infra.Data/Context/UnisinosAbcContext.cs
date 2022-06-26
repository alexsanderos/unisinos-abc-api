using Unisinos.Abc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Unisinos.Abc.Infra.Data.Context
{
    public class UnisinosAbcContext : DbContext
    {
        public UnisinosAbcContext(DbContextOptions<UnisinosAbcContext> options)
          : base(options)
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}