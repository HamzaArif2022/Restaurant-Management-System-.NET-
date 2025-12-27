using System;

namespace RestaurantManagSyst.Service.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentTime { get; set; }
        public decimal? Tips { get; set; }
    }
}


