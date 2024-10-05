using CreateStudent.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CreateStudent.Database
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> option) : base(option)
        {
            
        }


        public DbSet<Students> Students { get; set; }
    }
}
