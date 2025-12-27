using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IPaymentMethodService
    {
        ServiceResponse GetAllPaymentMethods();
        ServiceResponse GetPaymentMethodById(int id);
        ServiceResponse AddPaymentMethod(PaymentMethodDto paymentMethodDto);
        ServiceResponse UpdatePaymentMethod(PaymentMethodDto paymentMethodDto);
        ServiceResponse DeletePaymentMethod(int id);
        ServiceResponse SearchPaymentMethods(string searchTerm);
        ServiceResponse ToggleActiveStatus(int id);
    }
}

