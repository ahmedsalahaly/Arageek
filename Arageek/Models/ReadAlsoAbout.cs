using Arageek.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models
{
    public class ReadAlsoAbout : Audit
    {
        public string Categories { get; set; }
        public int CharactersId { get; set; }
    }
}
