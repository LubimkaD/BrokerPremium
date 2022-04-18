using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Infrastructure.Data.Models
{
    public class InsuranceClaim
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(20)]
        public string? ClaimNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string? PolicyNumber { get; set; }

        [Required]
        public DateTime DateOfAccident { get; set; } = DateTime.Now;

        [Required]
        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public ClaimStatus? ClaimStatus { get; set; }

        [Required]
        [Range(0, 100000)]
        [Column(TypeName = "decimal")]
        public decimal ClaimSum { get; set; }

        [Required]
        [StringLength(50)]
        public string? ImageOfClaim { get; set; }

        [Required]
        [Range(0,100000)]
        [Column(TypeName = "decimal")]
        public decimal ClaimCommission { get; set; }

        public ICollection<InsuredObject>? ClaimedObjects { get; set; }
    }
}
