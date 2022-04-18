using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Infrastructure.Data.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(10)]
        public string? Identificator { get; set; }

        [Required]
        public bool IsCompany { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? Address { get; set; }

        [Required]
        [StringLength(10)]
        [Phone]
        public string? Telefon { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateValidFrom { get; set; } = DateTime.Today;

        [Column(TypeName = "date")]
        public DateTime? DateValidTo { get; set; }

        public ICollection<InsurancePolicy>? InsurancePolices { get; set; }
    }
}
