using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Helpers;
using System.Collections.Generic;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IIngredientService
    {
        ServiceResponse GetAllIngredients();
        ServiceResponse GetIngredientById(int id);
        ServiceResponse AddIngredient(IngredientDto ingredientDto);
        ServiceResponse UpdateIngredient(IngredientDto ingredientDto);
        ServiceResponse DeleteIngredient(int id);
        ServiceResponse SearchIngredients(string searchTerm);
    }
}

