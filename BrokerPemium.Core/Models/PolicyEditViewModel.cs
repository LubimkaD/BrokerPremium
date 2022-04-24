using BrokerPremium.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Core.Models
{
    public class PolicyEditViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? PolicyNumber { get; set; }

        [Required]
        public int TypeOfInsuranceId { get; set; }

        [Required]
        [StringLength(10)]
        public string? TypeOfInsurance { get; set; }

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

        [Required]
        [StringLength(20)]
        public string? InsurerName { get; set; }

        [Required]
        [StringLength(10)]
        public string? CustomerIdentificator { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string? CustomerName { get; set; }
    }
}
