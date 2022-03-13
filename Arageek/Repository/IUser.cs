using Arageek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Repository
{
    public interface IUser :IGenericCRUD<User>
    {
        bool IsPasswordMatch(string Password, string ConfirmPassword);
        User LogIn(string UserName, string Password);
        bool IsUserValidate(User entity, bool IsUpdate = false);
        bool IsUserNameExist(string UserName);
        bool IsExist(int Id);
        bool IsExist(string UserName, string Password);
    }
}
