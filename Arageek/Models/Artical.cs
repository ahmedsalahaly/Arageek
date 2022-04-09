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
        public string ArticalName { get; set; } 
        public string Title { get; set; }
        public string Body { get; set; }
        public double Price { get; set; }
        public bool IsDisplay { get; set; }
        public int AutherId { get; set; }
        [ForeignKey("AutherId")]
        public Auther auther { get; set; }
        public int CategoreyId { get; set; }
        [ForeignKey("CategoreyId")]
        public MainCategorey categorey { get; set; }

    }
}
