using Arageek.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models
{
    public class Biography : Audit
    {
        public List<InspirationalCharacter> InspirationalCharacters { get; set; }
        public List<ReadAlsoAbout> ReadAlsoAbout { get; set; }
    }
}
