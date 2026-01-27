using Microsoft.EntityFrameworkCore;
using SimpleMVCCRUDApp.Models;

namespace SimpleMVCCRUDApp.Data
{
    public class StudentmvcDbContext : DbContext
    {
        public StudentmvcDbContext(DbContextOptions<StudentmvcDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
