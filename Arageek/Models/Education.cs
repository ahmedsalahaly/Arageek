using Arageek.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models
{
     public class Education : Audit
    {
        public List<StudyAbroadGuides> StudyAbroadGuide { get; set; }
        public string UndergraduateMajors { get; set; }
    }
}
