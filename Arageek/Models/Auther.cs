using Arageek.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models
{
    public class Auther:Humen
    {
        public string Bio { get; set; }
        public List<Artical> articals { get; set; }
    }
}
