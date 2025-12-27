using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Helpers;
using System.Collections.Generic;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IPaymentService
    {
        ServiceResponse GetAllPayments();
        ServiceResponse GetPaymentsByOrderId(int orderId);
        ServiceResponse AddPayment(PaymentDto paymentDto);
        ServiceResponse DeletePayment(int id);
    }
}


