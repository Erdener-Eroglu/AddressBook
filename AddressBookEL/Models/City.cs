using AddressBookEL.Models;
using System.ComponentModel.DataAnnotations;

namespace AddressBookEL.Entities
{
    public class City : BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string PlateCode { get; set; }

    }
}
