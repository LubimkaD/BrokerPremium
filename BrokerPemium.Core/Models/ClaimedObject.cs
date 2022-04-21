using BrokerPremium.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Core.Models
{
    public class ClaimedObject
    {
        [Required]
        public TypeOfObject TypeOfObject { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description { get; set; }
    }
}
