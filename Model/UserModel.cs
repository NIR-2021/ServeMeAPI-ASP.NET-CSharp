using System.ComponentModel.DataAnnotations;

namespace ServeMe_M2.Model
{
    public class UserModel
    {
        [Key]
        public int userId { get; set; }
        public string name { get; set; }    
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime cDate { get; set; }
        public string isVendor { get; set; }
        public string isDeleted { get; set; }
    }
}
