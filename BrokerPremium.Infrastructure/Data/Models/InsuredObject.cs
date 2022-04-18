using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Infrastructure.Data.Models
{
    public class InsuredObject
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public int TypeOfObjectId { get; set; }

        [ForeignKey(nameof(TypeOfObjectId))]
        public TypeOfObject? TypeOfObject { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description { get; set; }

        [Required]
        [StringLength(50)]
        public string? Image { get; set; }





    }
}
