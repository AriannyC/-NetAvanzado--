using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Domain.Models
{
    public class ModGene
    {
        public int Id { get; set; }
        public string Description { get; set; }


        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        public string AdditionalData { get; set; }
    
    
    }
}
