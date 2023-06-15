using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandyMan_Techlift.Models
{
    [Table("Services")]
    public class Services
    {
        [Key]
        [Column("Service_ID")]
        public Guid? ServiceID { get; set; }
        [Required]
        public string? ServiceName { get; set; }
        [Required]
        public string? ServiceDescription { get; set; }
        [Required]
        public int? ServicePrice { get; set; }
        [NotMapped]
        public IFormFile? ServicePicture { get; set; }

        public byte[]? ServiceImage { get; set; }    


    }
}
