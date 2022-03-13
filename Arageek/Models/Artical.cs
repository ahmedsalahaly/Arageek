using Arageek.Audits;
using Arageek.Models;
using Arageek.Models.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models
{
    public class Artical:Audit
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int AutherId { get; set; }
        [ForeignKey("AutherId")]
        public Auther auther { get; set; }
        public List<MainCategorey> mainCategoreys { get; set; }

    }
}
