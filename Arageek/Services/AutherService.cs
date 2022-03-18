using Arageek.Models;
using Arageek.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Services
{
    public class AutherService : IAuther
    {
        ArageekDbContext dbContext = new ArageekDbContext();
        public void Add(Auther entity)
        {
            if (!IsExist(entity))
            {
            entity.CreatedDate = DateTime.Now;
            dbContext.authers.Add(entity);
            dbContext.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            dbContext.authers.Remove(Get(Id));
            dbContext.SaveChanges();
        }

        public Auther Get(int Id)
        {
            return dbContext.authers.Find(Id);
        }

        public List<Auther> Get()
        {
            return dbContext.authers.ToList();
        }

        public bool IsExist(Auther Name)
        {
            return dbContext.authers.Any(x => x.Id == Name.Id);
        }

        public bool IsExistById(int Id)
        {
            return dbContext.authers.Any(x => x.Id == Id);
        }

        public void Update(Auther entity)
        {
         
         if (IsExist(entity))
         {
            Auther OldAuther = Get(entity.Id);
            OldAuther.FirstName = entity.FirstName;
            OldAuther.LastName = entity.LastName;
            OldAuther.BirthDay = entity.BirthDay;
            dbContext.authers.Update(OldAuther);
            dbContext.SaveChanges();
         }
        }
    }
}
