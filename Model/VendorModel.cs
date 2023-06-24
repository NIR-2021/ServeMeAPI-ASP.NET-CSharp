using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServeMe_M2.Model
{
    public class VendorModel
    {
        [Key]
        [Required]
        public int vendorId { get; set; }
        [Required]
        public string vendorName { get; set; }
        [Required]
        [EmailAddress]
        public string vendorEmail { get; set; }
        [Required]
        public string vendorPhone { get; set; }
        public string vendorDescription { get; set; }
        [Required]
        public string vendorAddress { get; set; }
        public string isActive { get; set; }
        public string isDeleted { get; set; }
        public DateTime? cDate { get; set; }
        [Required]
        public string Id { get; set; }
       
        [Required]
        public int categoryId { get; set; }
        
        [ForeignKey(nameof(Id))]
        public virtual ApiUser User { get; set; }
        [ForeignKey(nameof(categoryId))]
        public virtual Category Category { get; set; }

        public VendorModel()
        {
            cDate = DateTime.Now;
            isActive = "true"; 
            isDeleted = "false";

        }
    }
}
