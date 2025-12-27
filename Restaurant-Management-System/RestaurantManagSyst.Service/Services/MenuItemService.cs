using RestaurantManagSyst.Data;
using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Enums;
using RestaurantManagSyst.Service.Helpers;
using RestaurantManagSyst.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly RestaurantManagementEntities _context;

        public MenuItemService()
        {
            _context = new RestaurantManagementEntities();
        }

        public ServiceResponse GetAllMenuItems()
        {
            try
            {
                var menuItems = _context.MenuItems
                    .OrderBy(m => m.Category)
                    .ThenBy(m => m.Name)
                    .ToList()
                    .Select(m => m.ToDTO())
                    .ToList();

                return ServiceResponse.Success(
                    menuItems,
                    $"{menuItems.Count} article(s) trouvé(s)"
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse.Error(
                    ServiceResultCode.DatabaseError,
                    $"Erreur technique : {ex.Message}"
                );
            }
        }

        public ServiceResponse GetMenuItemById(int id)
        {
            try
            {
                var menuItem = _context.MenuItems.Find(id);

                if (menuItem == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun article trouvé avec l'ID {id}"
                    );
                }

                return ServiceResponse.Success(
                    menuItem.ToDTO(),
                    "Article trouvé"
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse.Error(
                    ServiceResultCode.DatabaseError,
                    $"Erreur technique : {ex.Message}"
                );
            }
        }

        public ServiceResponse AddMenuItem(MenuItemDto menuItemDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(menuItemDto.Name))
                {
                    return ServiceResponse.ValidationError(
                        "Le nom de l'article est obligatoire"
                    );
                }

                if (menuItemDto.Price <= 0)
                {
                    return ServiceResponse.ValidationError(
                        "Le prix doit être supérieur à zéro"
                    );
                }

                // Vérifier doublon
                var exists = _context.MenuItems.Any(m => m.Name.ToLower() == menuItemDto.Name.ToLower());
                if (exists)
                {
                    return ServiceResponse.DuplicateEntry(
                        "Un article avec ce nom existe déjà"
                    );
                }

                var menuItem = menuItemDto.ToEntity();
                menuItem.IsAvailable = true; // Available by default

                _context.MenuItems.Add(menuItem);
                _context.SaveChanges();

                menuItemDto.Id = menuItem.Id;

                return ServiceResponse.Success(
                    menuItemDto,
                    "Article ajouté avec succès"
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse.Error(
                    ServiceResultCode.DatabaseError,
                    $"Erreur technique : {ex.Message}"
                );
            }
        }

        public ServiceResponse UpdateMenuItem(MenuItemDto menuItemDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(menuItemDto.Name))
                {
                    return ServiceResponse.ValidationError(
                        "Le nom de l'article est obligatoire"
                    );
                }

                if (menuItemDto.Price <= 0)
                {
                    return ServiceResponse.ValidationError(
                        "Le prix doit être supérieur à zéro"
                    );
                }

                var menuItem = _context.MenuItems.Find(menuItemDto.Id);

                if (menuItem == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun article trouvé avec l'ID {menuItemDto.Id}"
                    );
                }

                // Vérifier doublon
                var exists = _context.MenuItems.Any(m => 
                    m.Name.ToLower() == menuItemDto.Name.ToLower() && 
                    m.Id != menuItemDto.Id);
                if (exists)
                {
                    return ServiceResponse.DuplicateEntry(
                        "Un autre article utilise déjà ce nom"
                    );
                }

                menuItem.Name = menuItemDto.Name;
                menuItem.Description = menuItemDto.Description;
                menuItem.Price = menuItemDto.Price;
                menuItem.BuyingPrice = menuItemDto.BuyingPrice;
                menuItem.Category = menuItemDto.Category;
                menuItem.PreparationTime = menuItemDto.PreparationTime;
                menuItem.IsAvailable = menuItemDto.IsAvailable;
                menuItem.Image = menuItemDto.Image;

                _context.SaveChanges();

                return ServiceResponse.Success(
                    true,
                    "Article mis à jour avec succès"
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse.Error(
                    ServiceResultCode.DatabaseError,
                    $"Erreur technique : {ex.Message}"
                );
            }
        }

        public ServiceResponse DeleteMenuItem(int id)
        {
            try
            {
                var menuItem = _context.MenuItems.Find(id);

                if (menuItem == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun article trouvé avec l'ID {id}"
                    );
                }

                // Check if menu item is used in orders (via MenuItemIngredients or other relations)
                var hasIngredients = _context.MenuItemIngredients.Any(mi => mi.MenuItemId == id);
                if (hasIngredients)
                {
                    return ServiceResponse.Error(
                        ServiceResultCode.BusinessRuleViolation,
                        "Cet article a des ingrédients associés. Suppression impossible."
                    );
                }

                _context.MenuItems.Remove(menuItem);
                _context.SaveChanges();

                return ServiceResponse.Success(
                    true,
                    "Article supprimé avec succès"
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse.Error(
                    ServiceResultCode.DatabaseError,
                    $"Erreur technique : {ex.Message}"
                );
            }
        }

        public ServiceResponse SearchMenuItems(string searchTerm)
        {
            try
            {
                var query = _context.MenuItems.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(m =>
                        m.Name.ToLower().Contains(searchTerm) ||
                        m.Description.ToLower().Contains(searchTerm) ||
                        m.Category.ToLower().Contains(searchTerm)
                    );
                }

                var menuItems = query
                    .OrderBy(m => m.Category)
                    .ThenBy(m => m.Name)
                    .ToList()
                    .Select(m => m.ToDTO())
                    .ToList();

                return ServiceResponse.Success(
                    menuItems,
                    $"{menuItems.Count} article(s) trouvé(s)"
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse.Error(
                    ServiceResultCode.DatabaseError,
                    $"Erreur technique : {ex.Message}"
                );
            }
        }

        public ServiceResponse GetMenuItemsByCategory(string category)
        {
            try
            {
                var query = _context.MenuItems.AsQueryable();

                if (!string.IsNullOrWhiteSpace(category))
                {
                    query = query.Where(m => m.Category == category);
                }

                var menuItems = query
                    .OrderBy(m => m.Name)
                    .ToList()
                    .Select(m => m.ToDTO())
                    .ToList();

                return ServiceResponse.Success(
                    menuItems,
                    $"{menuItems.Count} article(s) trouvé(s)"
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse.Error(
                    ServiceResultCode.DatabaseError,
                    $"Erreur technique : {ex.Message}"
                );
            }
        }

        public ServiceResponse ToggleAvailability(int id)
        {
            try
            {
                var menuItem = _context.MenuItems.Find(id);

                if (menuItem == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun article trouvé avec l'ID {id}"
                    );
                }

                menuItem.IsAvailable = !(menuItem.IsAvailable ?? false);
                _context.SaveChanges();

                string status = menuItem.IsAvailable == true ? "disponible" : "indisponible";
                return ServiceResponse.Success(
                    true,
                    $"Article marqué comme {status}"
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse.Error(
                    ServiceResultCode.DatabaseError,
                    $"Erreur technique : {ex.Message}"
                );
            }
        }
    }
}

