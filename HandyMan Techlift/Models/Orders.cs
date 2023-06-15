using System.ComponentModel.DataAnnotations;

namespace HandyMan_Techlift.Models
{
    public class Orders
    {
        [Key]
        public Guid OrderId { get; set; }

        public decimal OrdersTotal { get; set; }
        public Guid ServiceId { get; set; }
    }
}
