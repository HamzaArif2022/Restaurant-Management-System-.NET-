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
    public class IngredientService : IIngredientService
    {
        private readonly RestaurantManagementEntities _context;

        public IngredientService()
        {
            _context = new RestaurantManagementEntities();
        }

        public ServiceResponse GetAllIngredients()
        {
            try
            {
                var ingredients = _context.Ingredients
                    .OrderBy(i => i.Name)
                    .ToList()
                    .Select(i => new IngredientDto
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Quantity = i.Quantity,
                        Unit = i.Unit
                    })
                    .ToList();

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = $"{ingredients.Count} ingrédient(s) trouvé(s)",
                    Data = ingredients
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

        public ServiceResponse GetIngredientById(int id)
        {
            try
            {
                var ingredient = _context.Ingredients.Find(id);

                if (ingredient == null)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.NotFound,
                        Message = $"Aucun ingrédient trouvé avec l'ID {id}"
                    };
                }

                var ingredientDto = new IngredientDto
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit
                };

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = "Ingrédient trouvé",
                    Data = ingredientDto
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

        public ServiceResponse AddIngredient(IngredientDto ingredientDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(ingredientDto.Name))
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "Le nom de l'ingrédient est obligatoire"
                    };
                }

                if (ingredientDto.Quantity < 0)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "La quantité doit être positive"
                    };
                }

                if (string.IsNullOrWhiteSpace(ingredientDto.Unit))
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "L'unité de mesure est obligatoire"
                    };
                }

                // Check for duplicate
                var exists = _context.Ingredients.Any(i =>
                    i.Name.ToLower() == ingredientDto.Name.ToLower());

                if (exists)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.DuplicateEntry,
                        Message = "Un ingrédient avec ce nom existe déjà"
                    };
                }

                var ingredient = new Ingredients
                {
                    Name = ingredientDto.Name.Trim(),
                    Quantity = ingredientDto.Quantity,
                    Unit = ingredientDto.Unit.Trim()
                };

                _context.Ingredients.Add(ingredient);
                _context.SaveChanges();

                ingredientDto.Id = ingredient.Id;

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = "Ingrédient ajouté avec succès",
                    Data = ingredientDto
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

        public ServiceResponse UpdateIngredient(IngredientDto ingredientDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(ingredientDto.Name))
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "Le nom de l'ingrédient est obligatoire"
                    };
                }

                if (ingredientDto.Quantity < 0)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "La quantité doit être positive"
                    };
                }

                if (string.IsNullOrWhiteSpace(ingredientDto.Unit))
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "L'unité de mesure est obligatoire"
                    };
                }

                var ingredient = _context.Ingredients.Find(ingredientDto.Id);

                if (ingredient == null)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.NotFound,
                        Message = $"Aucun ingrédient trouvé avec l'ID {ingredientDto.Id}"
                    };
                }

                // Check for duplicate (excluding current ingredient)
                var exists = _context.Ingredients.Any(i =>
                    i.Name.ToLower() == ingredientDto.Name.ToLower() &&
                    i.Id != ingredientDto.Id);

                if (exists)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.DuplicateEntry,
                        Message = "Un autre ingrédient avec ce nom existe déjà"
                    };
                }

                ingredient.Name = ingredientDto.Name.Trim();
                ingredient.Quantity = ingredientDto.Quantity;
                ingredient.Unit = ingredientDto.Unit.Trim();

                _context.SaveChanges();

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = "Ingrédient mis à jour avec succès",
                    Data = ingredientDto
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

        public ServiceResponse DeleteIngredient(int id)
        {
            try
            {
                var ingredient = _context.Ingredients.Find(id);

                if (ingredient == null)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.NotFound,
                        Message = $"Aucun ingrédient trouvé avec l'ID {id}"
                    };
                }

                // Check if ingredient is used in menu items
                var isUsed = _context.MenuItemIngredients.Any(mi => mi.IngredientId == id);

                if (isUsed)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.BusinessRuleViolation,
                        Message = "Cet ingrédient est utilisé dans des articles du menu. Suppression impossible."
                    };
                }

                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = "Ingrédient supprimé avec succès"
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

        public ServiceResponse SearchIngredients(string searchTerm)
        {
            try
            {
                var query = _context.Ingredients.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(i =>
                        i.Name.ToLower().Contains(searchTerm) ||
                        i.Unit.ToLower().Contains(searchTerm));
                }

                var ingredients = query
                    .OrderBy(i => i.Name)
                    .ToList()
                    .Select(i => new IngredientDto
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Quantity = i.Quantity,
                        Unit = i.Unit
                    })
                    .ToList();

                return new ServiceResponse
                {
                    Code = ServiceResultCode.Success,
                    Message = $"{ingredients.Count} ingrédient(s) trouvé(s)",
                    Data = ingredients
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