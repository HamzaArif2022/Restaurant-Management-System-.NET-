using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.DTOs
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? BuyingPrice { get; set; }
        public string Category { get; set; }
        public int? PreparationTime { get; set; }
        public bool IsAvailable { get; set; }
        public string Image { get; set; }

        //
        public decimal? ProfitMargin => Price - (BuyingPrice ?? 0);
    }
}
