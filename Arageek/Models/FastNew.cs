using Arageek.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models
{
    public class FastNew : Audit
    {
        public string Discription { get; set; }
        public int NewsId { get; set; }
    }
}
