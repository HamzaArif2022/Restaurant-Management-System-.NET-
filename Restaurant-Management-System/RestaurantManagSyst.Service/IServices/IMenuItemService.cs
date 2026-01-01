using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IMenuItemService
    {
        ServiceResponse GetAllMenuItems();
        ServiceResponse GetMenuItemById(int id);
        ServiceResponse AddMenuItem(MenuItemDto menuItemDto);
        ServiceResponse UpdateMenuItem(MenuItemDto menuItemDto);
        ServiceResponse DeleteMenuItem(int id);
        ServiceResponse SearchMenuItems(string searchTerm);
        ServiceResponse GetMenuItemsByCategory(string category);
        ServiceResponse ToggleAvailability(int id);


    }
}

