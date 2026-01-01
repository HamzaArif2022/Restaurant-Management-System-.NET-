using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.DTOs
{
    public class MenuItemIngredientDto
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public int IngredientId { get; set; }
        public decimal QuantityRequired { get; set; }

        // Navigation properties
        public string MenuItemName { get; set; }
        public string IngredientName { get; set; }
        public string Unit { get; set; }
    }
}
