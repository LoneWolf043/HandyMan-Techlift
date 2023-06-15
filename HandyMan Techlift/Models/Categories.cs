using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HandyMan_Techlift.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [Column("Category_ID")]
        public Guid? CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        [NotMapped]
        public IFormFile? CategoryPicture { get; set; }
        public byte[]? CategoryImage { get; set; }

        




    }
}
