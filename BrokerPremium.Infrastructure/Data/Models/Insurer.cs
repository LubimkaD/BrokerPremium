using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Infrastructure.Data.Models
{
    public class Insurer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? Address { get; set; }

        [StringLength(50)]
        [Required]
        public string? ContactPerson { get; set; }
    }
}
