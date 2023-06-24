using ServeMe_M2.Model.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServeMe_M2.Model
{
    public class ServiceModel
    {
        [Key]
        public int serviceId { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public int? vendorId { get; set; }

        public float bid { get; set; }
        public int categoryId { get; set; }

        public string status { get; set; }

        [ForeignKey(nameof(vendorId))]
        public virtual VendorModel vendor { get; set; }
        [ForeignKey(nameof(categoryId))]
        public virtual Category category { get; set; }
        [ForeignKey(nameof(Id))]
        public virtual ApiUser user { get; set; }


        public ServiceModel()
        {
            this.status = "pending";
        }

    }
}
