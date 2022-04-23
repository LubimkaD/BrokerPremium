using System.ComponentModel.DataAnnotations;

namespace BrokerPremium.Core.Models
{
    public class CustomerListViewModel
    {
        public Guid Id { get; set; } 

        [Required]
        [StringLength(10)]
        public string? Identificator { get; set; }

        [Required]
        public bool IsCompany { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
    }
}
