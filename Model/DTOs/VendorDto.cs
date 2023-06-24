using System.ComponentModel.DataAnnotations;

namespace ServeMe_M2.Model.DTOs
{
    public class VendorDto
    {
        public int vendorId { get; set; }
        [Required]

        public string vendorName { get; set; }
        [Required]

        public string vendorEmail { get; set; }
        [Required]

        public string vendorPhone { get; set; }
        [Required]

        public string vendorAddress { get; set; }
        [Required]

        public string vendorDescription { get; set; }

        public string isActive { get; set; }
        public string isDeleted { get; set; }
        public DateTime? cDate { get; set; }
        [Required]

        public string Id { get; set; }
        [Required]

        public int categoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
