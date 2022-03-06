using Arageek.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models
{
    public class MainMenu : Audit
    {
        public List<Latestpost> LatestPosts { get; set; }
        public List<Promotional> Promotionals { get; set; }
        public List<FastNew> FastNews { get; set; }
    }
}
