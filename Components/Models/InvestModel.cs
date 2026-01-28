using System.ComponentModel.DataAnnotations;

namespace BlazorAppWeb.Components.Models
{
    public class InvestModel
    {
        [Required(ErrorMessage = "Investment type is required")]
        public string invest_type { get; set; } = string.Empty;
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0.000001, double.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public decimal quantity { get; set; } = 0;
        public string quantity_type { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price per unit is required")]
        [Range(0.000001, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal price { get; set; } = 0;
        public DateTime date { get; set; } = DateTime.Now;
        public bool is_sell { get; set; } = false;
        public int user_id { get; set; }
    }

    public class Investment : InvestModel
    {
        public int Id { get; set; }
    }
}