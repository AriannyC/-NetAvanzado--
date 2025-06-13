using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Domain.Models
{
    public class Ustoken
    {
        public int IdR { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string refreshtoken1 { get; set; }
        public DateTime TokenExpired { get; set; }

        public DateTime TokenCreated { get; set; }
    }
}
