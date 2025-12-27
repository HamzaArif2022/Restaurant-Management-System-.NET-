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
    public class PaymentService : IPaymentService
    {
        public ServiceResponse GetAllPayments()
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var payments = context.Payments
                        .OrderByDescending(p => p.PaymentTime)
                        .ToList();

                    var paymentDtos = payments.Select(p => new PaymentDto
                    {
                        Id = p.Id,
                        OrderId = p.OrderId,
                        Amount = p.Amount,
                        PaymentMethod = p.PaymentMethod,
                        PaymentTime = p.PaymentTime,
                        Tips = p.Tips
                    }).ToList();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Paiements récupérés avec succès",
                        Data = paymentDtos
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la récupération des paiements: {ex.Message}"
                };
            }
        }

        public ServiceResponse GetPaymentsByOrderId(int orderId)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var payments = context.Payments
                        .Where(p => p.OrderId == orderId)
                        .OrderByDescending(p => p.PaymentTime)
                        .ToList();

                    var paymentDtos = payments.Select(p => new PaymentDto
                    {
                        Id = p.Id,
                        OrderId = p.OrderId,
                        Amount = p.Amount,
                        PaymentMethod = p.PaymentMethod,
                        PaymentTime = p.PaymentTime,
                        Tips = p.Tips
                    }).ToList();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Paiements récupérés avec succès",
                        Data = paymentDtos
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la récupération des paiements: {ex.Message}"
                };
            }
        }

        public ServiceResponse AddPayment(PaymentDto paymentDto)
        {
            try
            {
                // Validation
                if (paymentDto.Amount <= 0)
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "Le montant du paiement doit être supérieur à zéro"
                    };
                }

                if (string.IsNullOrWhiteSpace(paymentDto.PaymentMethod))
                {
                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.ValidationError,
                        Message = "La méthode de paiement est requise"
                    };
                }

                using (var context = new RestaurantManagementEntities())
                {
                    // Verify order exists
                    var order = context.Orders.Find(paymentDto.OrderId);
                    if (order == null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.NotFound,
                            Message = "Commande non trouvée"
                        };
                    }

                    var payment = new Payments
                    {
                        OrderId = paymentDto.OrderId,
                        Amount = paymentDto.Amount,
                        PaymentMethod = paymentDto.PaymentMethod,
                        PaymentTime = DateTime.Now,
                        Tips = paymentDto.Tips ?? 0
                    };

                    context.Payments.Add(payment);
                    
                    // Update order status to "Completed" when payment is added
                    order.Status = "Completed";
                    
                    context.SaveChanges();

                    var createdPayment = new PaymentDto
                    {
                        Id = payment.Id,
                        OrderId = payment.OrderId,
                        Amount = payment.Amount,
                        PaymentMethod = payment.PaymentMethod,
                        PaymentTime = payment.PaymentTime,
                        Tips = payment.Tips
                    };

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Paiement ajouté avec succès et statut de la commande mis à jour",
                        Data = createdPayment
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de l'ajout du paiement: {ex.Message}"
                };
            }
        }

        public ServiceResponse DeletePayment(int id)
        {
            try
            {
                using (var context = new RestaurantManagementEntities())
                {
                    var payment = context.Payments.Find(id);

                    if (payment == null)
                    {
                        return new ServiceResponse
                        {
                            Code = ServiceResultCode.NotFound,
                            Message = "Paiement non trouvé"
                        };
                    }

                    context.Payments.Remove(payment);
                    context.SaveChanges();

                    return new ServiceResponse
                    {
                        Code = ServiceResultCode.Success,
                        Message = "Paiement supprimé avec succès"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    Code = ServiceResultCode.DatabaseError,
                    Message = $"Erreur lors de la suppression du paiement: {ex.Message}"
                };
            }
        }
    }
}


