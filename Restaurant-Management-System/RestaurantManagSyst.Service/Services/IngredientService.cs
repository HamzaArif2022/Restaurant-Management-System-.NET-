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
        public ServiceResponse GetAllIngredients()
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var ingredients = context.Ingredients
                        .OrderBy(i => i.Name)
                        .ToList();

                    var ingredientDtos = ingredients.Select(i => i.ToDto()).ToList();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Ingrédients récupérés avec succès",
                        Data = ingredientDtos
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la récupération des ingrédients: {ex.Message}"
                };
            }
        }

        public ServiceResponse GetIngredientById(int id)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var ingredient = context.Ingredients.Find(id);

                    if (ingredient == null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.NotFound,
                            Message = "Ingrédient non trouvé"
                        };
                    }

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Ingrédient récupéré avec succès",
                        Data = ingredient.ToDto()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la récupération de l'ingrédient: {ex.Message}"
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
                        Message = "Le nom de l'ingrédient est requis"
                    };
                }

                if (string.IsNullOrWhiteSpace(ingredientDto.Unit))
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "L'unité de mesure est requise"
                    };
                }

                if (ingredientDto.Quantity < 0)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "La quantité ne peut pas être négative"
                    };
                }

                using (var context = new RestaurantManagementEntities())
                {
                    // Check for duplicate name
                    var existingIngredient = context.Ingredients
                        .FirstOrDefault(i => i.Name.ToLower() == ingredientDto.Name.ToLower());

                    if (existingIngredient != null)
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

                    context.Ingredients.Add(ingredient);
                    context.SaveChanges();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Ingrédient ajouté avec succès",
                        Data = ingredient.ToDto()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de l'ajout de l'ingrédient: {ex.Message}"
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
                        Message = "Le nom de l'ingrédient est requis"
                    };
                }

                if (string.IsNullOrWhiteSpace(ingredientDto.Unit))
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "L'unité de mesure est requise"
                    };
                }

                if (ingredientDto.Quantity < 0)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "La quantité ne peut pas être négative"
                    };
                }

                using (var context = new RestaurantManagementEntities())
                {
                    var ingredient = context.Ingredients.Find(ingredientDto.Id);

                    if (ingredient == null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.NotFound,
                            Message = "Ingrédient non trouvé"
                        };
                    }

                    // Check for duplicate name (excluding current ingredient)
                    var existingIngredient = context.Ingredients
                        .FirstOrDefault(i => i.Name.ToLower() == ingredientDto.Name.ToLower() 
                                          && i.Id != ingredientDto.Id);

                    if (existingIngredient != null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.DuplicateEntry,
                            Message = "Un ingrédient avec ce nom existe déjà"
                        };
                    }

                    ingredient.Name = ingredientDto.Name.Trim();
                    ingredient.Quantity = ingredientDto.Quantity;
                    ingredient.Unit = ingredientDto.Unit.Trim();

                    context.SaveChanges();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Ingrédient mis à jour avec succès",
                        Data = ingredient.ToDto()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la mise à jour de l'ingrédient: {ex.Message}"
                };
            }
        }

        public ServiceResponse DeleteIngredient(int id)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var ingredient = context.Ingredients.Find(id);

                    if (ingredient == null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.NotFound,
                            Message = "Ingrédient non trouvé"
                        };
                    }

                    // Check if ingredient is used in menu items
                    if (ingredient.MenuItemIngredients.Any())
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.BusinessRuleViolation,
                            Message = "Impossible de supprimer cet ingrédient car il est utilisé dans des éléments du menu"
                        };
                    }

                    context.Ingredients.Remove(ingredient);
                    context.SaveChanges();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Ingrédient supprimé avec succès"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la suppression de l'ingrédient: {ex.Message}"
                };
            }
        }

        public ServiceResponse SearchIngredients(string searchTerm)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var query = context.Ingredients.AsQueryable();

                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        searchTerm = searchTerm.ToLower();
                        query = query.Where(i => i.Name.ToLower().Contains(searchTerm) ||
                                               i.Unit.ToLower().Contains(searchTerm));
                    }

                    var ingredients = query.OrderBy(i => i.Name).ToList();
                    var ingredientDtos = ingredients.Select(i => i.ToDto()).ToList();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Recherche effectuée avec succès",
                        Data = ingredientDtos
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la recherche: {ex.Message}"
                };
            }
        }
    }
}

