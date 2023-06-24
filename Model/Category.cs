using System.ComponentModel.DataAnnotations;

namespace ServeMe_M2.Model
{
    public class Category
    {
        [Key]
        [Required]
        public int categoryId { get; set; }
        public string Name { get; set; }
    }
}
