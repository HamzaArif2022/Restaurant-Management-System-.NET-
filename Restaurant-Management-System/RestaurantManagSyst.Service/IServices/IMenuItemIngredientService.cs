using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Helpers;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IMenuItemIngredientService
    {
        ServiceResponse GetIngredientsByMenuItemId(int menuItemId);

        ServiceResponse GetMenuItemsByIngredientId(int ingredientId);

        ServiceResponse AddMenuItemIngredient(MenuItemIngredientDto dto);

    
        ServiceResponse DeleteMenuItemIngredient(int id);

     
        ServiceResponse DeleteByMenuItemId(int menuItemId);


        ServiceResponse GetAllMenuItemIngredients();

       
        ServiceResponse IsIngredientUsed(int ingredientId);
    }
}