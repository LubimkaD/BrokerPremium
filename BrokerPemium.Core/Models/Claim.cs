using BrokerPremium.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Core.Models
{
    public class Claim
    {
        [Required]
        [StringLength(20)]
        public string? PolicyNumber { get; set; }

        [Required]
        public DateTime DateOfAccident { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string? ImageOfClaim { get; set; }

        [Required]
        public InsuredObject ClaimedObject { get; set; }
    }
}
