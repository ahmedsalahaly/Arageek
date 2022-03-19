using Arageek.Models;
using Arageek.Models.Categories;
using Arageek.Models.Users;
using Arageek.Parent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arageek
{
    public class ArageekDbContext : DbContext
    {
        public const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ArageekDb;Trusted_Connection=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public DbSet<Artical> articals { get; set; }
        public DbSet<Auther> authers { get; set; }
        public DbSet<MainCategorey> mainCategoreys { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public object User { get; internal set; }
    }
}
