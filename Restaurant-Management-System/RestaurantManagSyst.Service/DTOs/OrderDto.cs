using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string ClientName { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? TableNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
