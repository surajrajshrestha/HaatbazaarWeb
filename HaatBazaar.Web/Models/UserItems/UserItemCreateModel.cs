using System.ComponentModel.DataAnnotations;

namespace HaatBazaar.Web.Models.UserItems
{
    public class UserItemCreateModel
    {
        public int ItemId { get; set; }

        public string? ItemName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, float.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public float Quantity { get; set; }

        [Required(ErrorMessage = "Unit is required.")]
        [StringLength(50, ErrorMessage = "Unit cannot be longer than 50 characters.")]
        public string? Unit { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public decimal Price { get; set; }

        public List<BaseItemModel>? Items { get; set; }
    }

    public class BaseItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
