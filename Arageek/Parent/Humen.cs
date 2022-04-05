using Arageek.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Parent
{
    public abstract class Humen : Audit
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public DateTime? BirthDay { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}