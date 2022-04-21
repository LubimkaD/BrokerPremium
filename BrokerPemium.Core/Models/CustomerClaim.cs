using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Core.Models
{
    public class CustomerClaim
    {
        [Required]
        [StringLength(10)]
        public string? Identificator { get; set; }

        [Required]
        public Claim Claim { get; set; }
    }
}
