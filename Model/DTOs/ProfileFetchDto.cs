using System.ComponentModel.DataAnnotations;

namespace ServeMe_M2.Model.DTOs
{
    public class ProfileFetchDto
    {
        [Required]
        public string Id { get; set; }
        [Required]

        public string email { get; set; }
    }
}
