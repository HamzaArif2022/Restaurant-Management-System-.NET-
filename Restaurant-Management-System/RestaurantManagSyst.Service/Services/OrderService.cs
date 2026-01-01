using RestaurantManagSyst.Data;
using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Enums;
using RestaurantManagSyst.Service.Helpers;
using RestaurantManagSyst.Service.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace RestaurantManagSyst.Service.Services
{
    public class OrderService : IOrderService
    {
       
        public ServiceResponse GetAllOrders()
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var orders = context.Orders
                        .OrderByDescending(o => o.OrderDate)
                        .ToList();

                    var orderDtos = orders.Select(o => o.ToDTO()).ToList();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Commandes récupérées avec succès",
                        Data = orderDtos
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la récupération des commandes: {ex.Message}"
                };
            }
        }

        public ServiceResponse GetOrderById(int id)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var order = context.Orders.Find(id);

                    if (order == null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.NotFound,
                            Message = "Commande non trouvée"
                        };
                    }

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Commande récupérée avec succès",
                        Data = order.ToDTO()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la récupération de la commande: {ex.Message}"
                };
            }
        }

        public ServiceResponse CreateOrder(OrderDto orderDto, List<OrderItemDto> orderItems)
        {
            try
            {
                // Validation
                if (orderItems == null || orderItems.Count == 0)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "La commande doit contenir au moins un article"
                    };
                }

                // Calculate total from order items
                decimal totalAmount = orderItems.Sum(item => item.Subtotal);

                using (var context = new RestaurantManagementEntities())
                {
                    // Build order items details for Notes field
                    var orderItemsDetails = new StringBuilder();
                    orderItemsDetails.AppendLine("=== ORDER ITEMS ===");
                    foreach (var item in orderItems)
                    {
                        orderItemsDetails.AppendLine($"{item.MenuItemName} x{item.Quantity} @ {item.Price:C} = {item.Subtotal:C}");
                    }
                    orderItemsDetails.AppendLine($"=== TOTAL: {totalAmount:C} ===");

                    // Combine with existing notes if any
                    string fullNotes = string.IsNullOrWhiteSpace(orderDto.Notes)
                        ? orderItemsDetails.ToString()
                        : $"{orderDto.Notes}\n\n{orderItemsDetails}";

                    var order = new Orders
                    {
                        ClientId = orderDto.ClientId,
                        EmployeeId = orderDto.EmployeeId,
                        TableNumber = orderDto.TableNumber,
                        OrderDate = DateTime.Now,
                        Status = "Pending",
                        Notes = fullNotes,
                        TotalAmount = totalAmount
                    };

                    context.Orders.Add(order);
                    context.SaveChanges();

                    // Now create OrderItems records
                    int orderId = order.Id;
                    foreach (var item in orderItems)
                    {
                        // Insert OrderItem using raw SQL since it's not in the EF model
                        string sql = @"INSERT INTO OrderItems (OrderId, MenuItemId, Quantity, SpecialRequests, ItemStatus) 
                                       VALUES (@p0, @p1, @p2, @p3, @p4)";

                        context.Database.ExecuteSqlCommand(sql,
                            orderId,
                            item.MenuItemId,
                            item.Quantity,
                            (object)null, // SpecialRequests - can be null
                            "Waiting" // ItemStatus - default to "Waiting"
                        );
                    }

                    // Return updated order with ID
                    var createdOrder = order.ToDTO();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Commande créée avec succès",
                        Data = createdOrder
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la création de la commande: {ex.Message}"
                };
            }
        }

        public ServiceResponse UpdateOrder(OrderDto orderDto)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var order = context.Orders.Find(orderDto.Id);

                    if (order == null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.NotFound,
                            Message = "Commande non trouvée"
                        };
                    }

                    order.ClientId = orderDto.ClientId;
                    order.EmployeeId = orderDto.EmployeeId;
                    order.TableNumber = orderDto.TableNumber;
                    order.Status = orderDto.Status;
                    order.Notes = orderDto.Notes;
                    order.TotalAmount = orderDto.TotalAmount;

                    context.SaveChanges();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Commande mise à jour avec succès",
                        Data = order.ToDTO()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la mise à jour de la commande: {ex.Message}"
                };
            }
        }

        public ServiceResponse UpdateOrderStatus(int orderId, string status)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var order = context.Orders.Find(orderId);

                    if (order == null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.NotFound,
                            Message = "Commande non trouvée"
                        };
                    }

                    order.Status = status;
                    context.SaveChanges();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Statut de la commande mis à jour avec succès",
                        Data = order.ToDTO()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la mise à jour du statut: {ex.Message}"
                };
            }
        }

        public ServiceResponse DeleteOrder(int id)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var order = context.Orders.Find(id);

                    if (order == null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.NotFound,
                            Message = "Commande non trouvée"
                        };
                    }

                    // Check if order has payments
                    if (order.Payments.Any())
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.BusinessRuleViolation,
                            Message = "Impossible de supprimer une commande qui a des paiements associés"
                        };
                    }

                    // Delete OrderItems first (using raw SQL since it's not in EF model)
                    context.Database.ExecuteSqlCommand("DELETE FROM OrderItems WHERE OrderId = @p0", order.Id);


                    context.Orders.Remove(order);
                    context.SaveChanges();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Commande supprimée avec succès"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la suppression de la commande: {ex.Message}"
                };
            }
        }

        public ServiceResponse SearchOrders(string searchTerm)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var query = context.Orders.AsQueryable();

                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        searchTerm = searchTerm.ToLower();
                        int searchId;
                        bool isNumeric = int.TryParse(searchTerm, out searchId);

                        query = query.Where(o =>
                            (isNumeric && o.Id == searchId) ||
                            (isNumeric && o.TableNumber.HasValue && o.TableNumber.Value == searchId) ||
                            o.Status.ToLower().Contains(searchTerm) ||
                            (o.Clients != null && o.Clients.Name.ToLower().Contains(searchTerm)) ||
                            (o.Employees != null && o.Employees.Name.ToLower().Contains(searchTerm))
                        );
                    }

                    var orders = query.OrderByDescending(o => o.OrderDate).ToList();
                    var orderDtos = orders.Select(o => o.ToDTO()).ToList();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Recherche effectuée avec succès",
                        Data = orderDtos
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


