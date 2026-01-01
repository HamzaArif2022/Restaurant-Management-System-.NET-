using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IInventoryService
    {
        ServiceResponse GetProductInventory();
        ServiceResponse GetIngredientInventory();

        ServiceResponse UpdateProductQuantity(int productInventoryId, int quantity);
        ServiceResponse UpdateIngredientQuantity(int ingredientId, decimal quantity);
    }
}

