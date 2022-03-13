using Arageek.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Repository
{
    public interface IUserRole :IGenericCRUD<UserRole>, IValidation<UserRole>
    {
    }
}
