using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Infrastructure.Data.Models
{
    public class InsurancePolicy
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(20)]
        public string? PolicyNumber { get; set; }

        [Required]
        public int TypeOfInsuranceId { get; set; }

        [ForeignKey(nameof(TypeOfInsuranceId))]
        public TypeOfInsurance? TypeOfInsurance { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateValidFrom { get; set; } = DateTime.Today;

        [Column(TypeName = "date")]
        public DateTime? DateValidTo { get; set; }

        [Required]
        [Range(0, 200000)]
        [Column(TypeName = "decimal")]
        public decimal InsSuma { get; set; }

        [Required]
        [Range(0, 100000)]
        [Column(TypeName = "decimal")]
        public decimal InsCommission { get; set; }

        public IList<InsuredObject>? InsuredObjects { get; set; } = new List<InsuredObject>();

        public IList<InsuranceClaim>? InsClaims { get; set; } = new List<InsuranceClaim>();

        [Required]
        public int InsurerId { get; set; }

        [ForeignKey(nameof(InsurerId))]
        public Insurer? Insurer { get; set; }


    }
}
