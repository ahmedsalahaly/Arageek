using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Repository
{
    public interface IGenericCRUD<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int Id);
        T Get(int id);
        List<T> Get();
    }
}
