using Arageek.Models;
using Arageek.Models.Users;
using Arageek.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Services
{
    
        public class UserRoleService : IUserRole
        {
            ArageekDbContext dbContext = new ArageekDbContext();
            public void Add(UserRole model)
            {
                if (!IsExist(model))
                {
                    dbContext.userRoles.Add(model);
                    dbContext.SaveChanges();
                }
            }


            public void Delete(int Id)
            {
                if (IsExistById(Id))
                {
                    dbContext.userRoles.Remove(Get(Id));
                }
            }

            public UserRole Get(int id)
            {
                if (IsExistById(id))
                {
                    return dbContext.userRoles.Find(id);
                }
                return null;
            }

            public List<UserRole> Get()
            {
                return dbContext.userRoles.ToList();
            }

            public bool IsExist(UserRole entity)
            {
                return dbContext.userRoles.Any(x => x.Id == entity.Id || x.Name == entity.Name);
            }

            public bool IsExistById(int Id)
            {
                return dbContext.userRoles.Any(x => x.Id == Id);
            }

            public void Update(UserRole entity)
            {
                throw new NotImplementedException();
            }
           
        }
}
