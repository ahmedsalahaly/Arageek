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
        ArageekDbContext context = new ArageekDbContext();
        public void Add(Auther entity)
        {
            entity.CreatedDate = DateTime.Now;
            context.authers.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.authers.Remove(Get(Id));
            context.SaveChanges();
        }

        public Auther Get(int Id)
        {
            return context.authers.Find(Id);
        }

        public List<Auther> Get()
        {
            return context.authers.ToList();
        }

        public bool IsExist(Auther Name)
        {
            return context.authers.Any(x => x.Id == Name.Id);
        }

        public bool IsExistById(int Id)
        {
            return context.authers.Any(x => x.Id == Id);
        }

        public void Update(Auther entity)
        {
            Auther OldAuther = Get(entity.Id);
            OldAuther.FirstName = entity.FirstName;
            OldAuther.LastName = entity.LastName;
            OldAuther.BirthDay = entity.BirthDay;
            context.authers.Update(OldAuther);
            context.SaveChanges();
        }
    }
}
