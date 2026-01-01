using RestaurantManagSyst.Data;
using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Enums;
using RestaurantManagSyst.Service.Helpers;
using RestaurantManagSyst.Service.IServices;
using System;
using System.Linq;

namespace RestaurantManagSyst.Service.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly RestaurantManagementEntities _context;

        public InventoryService()
        {
            _context = new RestaurantManagementEntities();
        }

        // ===================== PRODUITS =====================
        public ServiceResponse GetProductInventory()
        {
            try
            {
                var products = _context.ProductInventory
                    .OrderBy(p => p.MenuItems.Name)
                    .Select(p => new
                    {
                        p.Id,
                        Produit = p.MenuItems.Name,
                        p.Quantity,
                        p.ReorderLevel,
                        p.LastUpdated
                    })
                    .ToList();

                return ServiceResponse.Success(
                    products,
                    $"{products.Count} produit(s) trouvé(s)"
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

        // ===================== INGREDIENTS =====================
        public ServiceResponse GetIngredientInventory()
        {
            try
            {
                var ingredients = _context.IngredientInventory
                    .OrderBy(i => i.Name)
                    .Select(i => new
                    {
                        i.IngredientId,
                        i.Name,
                        i.Quantity,
                        i.Unit,
                        i.ReorderLevel
                    })
                    .ToList();

                return ServiceResponse.Success(
                    ingredients,
                    $"{ingredients.Count} ingrédient(s) trouvé(s)"
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

        // ===================== UPDATE PRODUIT =====================
        public ServiceResponse UpdateProductQuantity(int productInventoryId, int quantity)
        {
            try
            {
                if (quantity < 0)
                {
                    return ServiceResponse.ValidationError(
                        "La quantité ne peut pas être négative"
                    );
                }

                var product = _context.ProductInventory
                    .FirstOrDefault(p => p.Id == productInventoryId);

                if (product == null)
                {
                    return ServiceResponse.NotFound(
                        "Produit introuvable"
                    );
                }

                product.Quantity = quantity;
                product.LastUpdated = DateTime.Now;

                _context.SaveChanges();

                return ServiceResponse.Success(
                    null,
                    "Quantité du produit mise à jour"
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

        // ===================== UPDATE INGREDIENT =====================
        public ServiceResponse UpdateIngredientQuantity(int ingredientId, decimal quantity)
        {
            try
            {
                if (quantity < 0)
                {
                    return ServiceResponse.ValidationError(
                        "La quantité ne peut pas être négative"
                    );
                }

                var ingredient = _context.IngredientInventory
                    .FirstOrDefault(i => i.IngredientId == ingredientId);

                if (ingredient == null)
                {
                    return ServiceResponse.NotFound(
                        "Ingrédient introuvable"
                    );
                }

                ingredient.Quantity = quantity;

                _context.SaveChanges();

                return ServiceResponse.Success(
                    null,
                    "Quantité de l’ingrédient mise à jour"
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
