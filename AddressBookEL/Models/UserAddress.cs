using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBookEL.Models
{
    public class UserAddress : BaseNumeric
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Details { get; set; }

        //public int UserId { get; set; }

        public int NeighbourhoodId { get; set; }

        public bool isDefaultAddress { get; set; }

        [ForeignKey("NeighbourhoodId")]
        public virtual Neighbourhood Neighbourhood { get; set; }
    }
}
