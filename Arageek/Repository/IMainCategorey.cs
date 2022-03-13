using Arageek.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Repository
{
    public interface IMainCategorey: IGenericCRUD<MainCategorey>, IValidation<MainCategorey>
    {
    }
}
