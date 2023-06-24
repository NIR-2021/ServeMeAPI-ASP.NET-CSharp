using System.ComponentModel.DataAnnotations;

namespace ServeMe_M2.Model.DTOs
{
    public class ApiUserDto : LoginDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
               
    }
}
