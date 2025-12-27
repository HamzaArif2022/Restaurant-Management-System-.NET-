using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Helpers;
using System.Collections.Generic;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IOrderService
    {
        ServiceResponse GetAllOrders();
        ServiceResponse GetOrderById(int id);
        ServiceResponse CreateOrder(OrderDto orderDto, List<OrderItemDto> orderItems);
        ServiceResponse UpdateOrder(OrderDto orderDto);
        ServiceResponse UpdateOrderStatus(int orderId, string status);
        ServiceResponse DeleteOrder(int id);
        ServiceResponse SearchOrders(string searchTerm);
    }
}


