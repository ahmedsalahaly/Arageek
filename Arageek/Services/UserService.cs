using Arageek.Models;
using Arageek.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Services
{
    public class UserService : IUser
    {
        ArageekDbContext dbContext = new ArageekDbContext();
        public void Add(User entity)
        {
            if (IsUserValidate(entity))
            {
                entity.UserName = entity.UserName.ToUpper();
                entity.Password = entity.Password.ToUpper();
                entity.CreatedDate = DateTime.Now;
                dbContext.User.Add(entity);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            if (IsExist(Id))
            {
                dbContext.User.Remove(Get(Id));
            }
        }

        public User Get(int id)
        {
            if (IsExist(id))
            {
                return dbContext.User.Find(id);
            }
            return null;
        }

        public List<User> Get()
        {
            return dbContext.User.ToList();
        }

        public bool IsExist(int Id)
        {
            return dbContext.User.Any(x => x.Id == Id);
        }

        public bool IsExist(string UserName, string Password)
        {
            return dbContext.User.Any(x => x.UserName == UserName && x.Password == Password);
        }

        public bool IsPasswordMatch(string Password, string ConfirmPassword)
        {
            if (Password.ToUpper() == ConfirmPassword.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUserNameExist(string UserName)
        {
            return dbContext.User.Any(x => x.UserName == UserName);
        }

        public bool IsUserValidate(User entity, bool IsUpdate = false)
        {
            if (!string.IsNullOrEmpty(entity.FirstName) &&
                            !string.IsNullOrEmpty(entity.LastName) &&
                            !string.IsNullOrEmpty(entity.UserName) &&
                            !string.IsNullOrEmpty(entity.Password) &&
                            !string.IsNullOrEmpty(entity.ConfirmPassword))
            {
                if (IsUpdate)
                {
                    if (IsUserNameExist(entity.UserName) &&
                        IsPasswordMatch(entity.Password, entity.ConfirmPassword))
                    {
                        return true;
                    }
                }
                else
                {
                    if (!IsUserNameExist(entity.UserName) &&
                        IsPasswordMatch(entity.Password, entity.ConfirmPassword))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public User LogIn(string UserName, string Password)
        {
            if (IsExist(UserName.ToUpper(), Password.ToUpper()))
            {
                return dbContext.User.Where(x => x.UserName == UserName && x.Password == Password)
                    .Include(x => x.addresses).Include(x => x.mobiles).Include(x => x.userRole).FirstOrDefault();
            }
            return null;
        }

        public void Update(User entity)
        {
            if (IsExist(entity.Id) && IsUserValidate(entity, true))
            {
                User NewEntity = Get(entity.Id);
                NewEntity.UserName = entity.UserName;
                NewEntity.Password = entity.Password;
                NewEntity.FirstName = entity.FirstName;
                NewEntity.LastName = entity.LastName;

                dbContext.User.Update(NewEntity);
                dbContext.SaveChanges();
            }
        }
    }
}
