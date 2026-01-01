using RestaurantManagSyst.Data;
using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Enums;
using RestaurantManagSyst.Service.Helpers;
using RestaurantManagSyst.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagSyst.Service.Services
{
    public class MenuItemIngredientService : IMenuItemIngredientService
    {
        private readonly RestaurantManagementEntities _context;

        public MenuItemIngredientService()
        {
            _context = new RestaurantManagementEntities();
        }

        public ServiceResponse GetIngredientsByMenuItemId(int menuItemId)
        {
            try
            {
                var menuItemIngredients = _context.MenuItemIngredients
                    .Where(mi => mi.MenuItemId == menuItemId)
                    .ToList()
                    .Select(mi => new MenuItemIngredientDto
                    {
                        Id = mi.Id,
                        MenuItemId = mi.MenuItemId,
                        IngredientId = mi.IngredientId,
                        QuantityRequired = mi.QuantityRequired,
                        IngredientName = _context.Ingredients.FirstOrDefault(i => i.Id == mi.IngredientId)?.Name,
                        Unit = _context.Ingredients.FirstOrDefault(i => i.Id == mi.IngredientId)?.Unit
                    })
                    .ToList();

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = $"{menuItemIngredients.Count} ingrédient(s) lié(s) trouvé(s)",
                    Data = menuItemIngredients
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur technique : {ex.Message}"
                };
            }
        }

        public ServiceResponse GetMenuItemsByIngredientId(int ingredientId)
        {
            try
            {
                var menuItemIngredients = _context.MenuItemIngredients
                    .Where(mi => mi.IngredientId == ingredientId)
                    .ToList()
                    .Select(mi => new MenuItemIngredientDto
                    {
                        Id = mi.Id,
                        MenuItemId = mi.MenuItemId,
                        IngredientId = mi.IngredientId,
                        QuantityRequired = mi.QuantityRequired,
                        MenuItemName = _context.MenuItems.FirstOrDefault(m => m.Id == mi.MenuItemId)?.Name,
                        IngredientName = _context.Ingredients.FirstOrDefault(i => i.Id == mi.IngredientId)?.Name,
                        Unit = _context.Ingredients.FirstOrDefault(i => i.Id == mi.IngredientId)?.Unit
                    })
                    .ToList();

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = $"{menuItemIngredients.Count} article(s) trouvé(s)",
                    Data = menuItemIngredients
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur technique : {ex.Message}"
                };
            }
        }

        public ServiceResponse AddMenuItemIngredient(MenuItemIngredientDto dto)
        {
            try
            {
                // Validation
                if (dto.MenuItemId <= 0)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "L'ID de l'article du menu est invalide"
                    };
                }

                if (dto.IngredientId <= 0)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "L'ID de l'ingrédient est invalide"
                    };
                }

                if (dto.QuantityRequired <= 0)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "La quantité requise doit être supérieure à zéro"
                    };
                }

                // Check if MenuItem exists
                var menuItemExists = _context.MenuItems.Any(m => m.Id == dto.MenuItemId);
                if (!menuItemExists)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.NotFound,
                        Message = "L'article du menu n'existe pas"
                    };
                }

                // Check if Ingredient exists
                var ingredientExists = _context.Ingredients.Any(i => i.Id == dto.IngredientId);
                if (!ingredientExists)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.NotFound,
                        Message = "L'ingrédient n'existe pas"
                    };
                }

                // Check for duplicate link
                var exists = _context.MenuItemIngredients.Any(mi =>
                    mi.MenuItemId == dto.MenuItemId &&
                    mi.IngredientId == dto.IngredientId);

                if (exists)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.DuplicateEntry,
                        Message = "Cet ingrédient est déjà lié à cet article"
                    };
                }

                var menuItemIngredient = new MenuItemIngredients
                {
                    MenuItemId = dto.MenuItemId,
                    IngredientId = dto.IngredientId,
                    QuantityRequired = dto.QuantityRequired
                };

                _context.MenuItemIngredients.Add(menuItemIngredient);
                _context.SaveChanges();

                dto.Id = menuItemIngredient.Id;

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = "Ingrédient lié avec succès",
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur technique : {ex.Message}"
                };
            }
        }

        public ServiceResponse DeleteMenuItemIngredient(int id)
        {
            try
            {
                var menuItemIngredient = _context.MenuItemIngredients.Find(id);

                if (menuItemIngredient == null)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.NotFound,
                        Message = "Lien ingrédient-article non trouvé"
                    };
                }

                _context.MenuItemIngredients.Remove(menuItemIngredient);
                _context.SaveChanges();

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = "Lien supprimé avec succès"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur technique : {ex.Message}"
                };
            }
        }

        public ServiceResponse DeleteByMenuItemId(int menuItemId)
        {
            try
            {
                var links = _context.MenuItemIngredients
                    .Where(mi => mi.MenuItemId == menuItemId)
                    .ToList();

                if (links.Any())
                {
                    _context.MenuItemIngredients.RemoveRange(links);
                    _context.SaveChanges();
                }

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = $"{links.Count} lien(s) supprimé(s)"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur technique : {ex.Message}"
                };
            }
        }

        public ServiceResponse GetAllMenuItemIngredients()
        {
            try
            {
                var menuItemIngredients = _context.MenuItemIngredients
                    .ToList()
                    .Select(mi => new MenuItemIngredientDto
                    {
                        Id = mi.Id,
                        MenuItemId = mi.MenuItemId,
                        IngredientId = mi.IngredientId,
                        QuantityRequired = mi.QuantityRequired,
                        MenuItemName = _context.MenuItems.FirstOrDefault(m => m.Id == mi.MenuItemId)?.Name,
                        IngredientName = _context.Ingredients.FirstOrDefault(i => i.Id == mi.IngredientId)?.Name,
                        Unit = _context.Ingredients.FirstOrDefault(i => i.Id == mi.IngredientId)?.Unit
                    })
                    .ToList();

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = $"{menuItemIngredients.Count} lien(s) trouvé(s)",
                    Data = menuItemIngredients
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur technique : {ex.Message}"
                };
            }
        }

        public ServiceResponse IsIngredientUsed(int ingredientId)
        {
            try
            {
                var isUsed = _context.MenuItemIngredients.Any(mi => mi.IngredientId == ingredientId);

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = isUsed ? "L'ingrédient est utilisé" : "L'ingrédient n'est pas utilisé",
                    Data = isUsed
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur technique : {ex.Message}"
                };
            }
        }
    }
}