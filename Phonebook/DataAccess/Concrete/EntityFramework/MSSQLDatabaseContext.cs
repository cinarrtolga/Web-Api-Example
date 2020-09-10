using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class MSSQLDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=OnlinePhoneBook;Integrated Security=True;");
        }

        public DbSet<Phones> Tbl_Phones { get; set; }
        public DbSet<Users> Tbl_Users { get; set; }
    }
}
