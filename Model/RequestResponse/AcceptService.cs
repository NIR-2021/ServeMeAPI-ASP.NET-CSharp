using System.ComponentModel.DataAnnotations;

namespace ServeMe_M2.Model.RequestResponse
{
    public class AcceptService
    {
        [Required]
        public int serviceId { get; set; }
        public string Id { get; set; }

    }
}
