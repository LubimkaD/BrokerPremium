using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerPremium.Core.Models
{
    public class CustomerViewModel
    {
        //[Required]
        //[StringLength(10)]
        //public string? CustomerIdentificator { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string? CustomerName { get; set; }
    }
}
