using System.ComponentModel.DataAnnotations;

namespace BrokerPremium.Core.Models
{
    public class InsurerViewModel
    {
        [Required]
        public int InsurerId { get; set; }

        [Required]
        [StringLength(20)]
        public string? InsurerName { get; set; }
    }
}
