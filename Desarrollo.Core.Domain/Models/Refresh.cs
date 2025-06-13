using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Domain.Models
{
    public class Refresh
    {
        
            [Required]
            public string refreshtoken { get; set; }
            public DateTime Expires { get; set; }

            public DateTime Created { get; set; } = DateTime.Now;
        
    }
}
