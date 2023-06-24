using System.ComponentModel.DataAnnotations;

namespace ServeMe_M2.Model.DTOs
{
    public class VendorRegDto
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

       
        [Required]

        public string Id { get; set; }

        public int categoryId { get; set; }

        [Required]
        public int[] categoryIds { get; set; }

    }
}
