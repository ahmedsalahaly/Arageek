using Arageek.Models;
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
        public DbSet<Art> arts { get; set; }
        public DbSet<Biography> biographies { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<FastNew> fastNews { get; set; }
        public DbSet<InspirationalCharacter> inspirationalCharacters { get; set; }
        public DbSet<Latestpost> latestposts { get; set; }
        public DbSet<MainMenu> mainMenus { get; set; }
        public DbSet<Promotional> promotionals { get; set; }
        public DbSet<ReadAlsoAbout> readAlsoAbouts { get; set; }
        public DbSet<StudyAbroadGuides> studyAbroadGuides { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
