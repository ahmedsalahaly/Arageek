using Arageek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Repository
{
    public interface IAuther : IGenericCRUD<Auther>, IValidation<Auther>
    {
        
    }
}
