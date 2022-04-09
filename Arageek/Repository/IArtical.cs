using Arageek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Repository
{
    public interface IArtical : IGenericCRUD<Artical>
    {
        void Dective(int id);
        List<Artical> GetByAuther(int ID);
        List<Artical> GetAll();
    }
}
