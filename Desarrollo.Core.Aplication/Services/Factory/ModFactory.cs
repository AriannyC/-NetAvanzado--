using Desarrollo.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Aplication.Services.Factory
{
    public  class ModFactory
    {

        public static ModGene CreateHighPriorityTask(string description)
        {
            return new ModGene
            {
                Description = description,
                DueDate = DateTime.Now.AddDays(1),
                Status = "Pending",
                AdditionalData = "High Priority"

            };
        }





        }
}
