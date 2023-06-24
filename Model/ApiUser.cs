using Microsoft.AspNetCore.Identity;

namespace ServeMe_M2.Model
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //public string password { get; set; }


    }
}
