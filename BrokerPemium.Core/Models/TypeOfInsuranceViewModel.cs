using System.ComponentModel.DataAnnotations;

namespace BrokerPremium.Core.Models
{
    public class TypeOfInsuranceViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string? Name { get; set; }
    }
}
