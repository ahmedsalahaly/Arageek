using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models.Categories
{
    public class MainCategorey
    {

        public int Id { get; set; }
        string Name { get; set; }
        public List<Artical> articals { get; set; }
    }
}
