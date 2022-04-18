using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Infrastructure.Data.Models
{
    public class ClaimStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string? Status { get; set; }
    }
}
