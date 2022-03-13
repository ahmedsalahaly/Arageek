using Arageek.Models.Users;
using Arageek.Parent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Models
{
    public class User : Humen
    {
      
        public string UserName { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public int UserRoleId { get; set; }
        [ForeignKey("UserRoleId")]
        public UserRole userRole { get; set; }
    }
}
