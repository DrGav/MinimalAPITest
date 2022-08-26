using CRUD_API_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API_Test.DAL
{
    public class DiaryDbContext : DbContext
    {
        public DiaryDbContext(DbContextOptions<DiaryDbContext> options) : base(options)
        {

        }

        public DbSet<DiaryEntry> DiaryEntry { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
