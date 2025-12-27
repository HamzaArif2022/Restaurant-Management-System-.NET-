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
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly RestaurantManagementEntities _context;

        public PaymentMethodService()
        {
            _context = new RestaurantManagementEntities();
        }

        public ServiceResponse GetAllPaymentMethods()
        {
            try
            {
                var paymentMethods = _context.PaymentMethods
                    .OrderBy(p => p.Label)
                    .ToList()
                    .Select(p => p.ToDTO())
                    .ToList();

                return ServiceResponse.Success(
                    paymentMethods,
                    $"{paymentMethods.Count} méthode(s) de paiement trouvée(s)"
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

        public ServiceResponse GetPaymentMethodById(int id)
        {
            try
            {
                var paymentMethod = _context.PaymentMethods.Find(id);

                if (paymentMethod == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucune méthode de paiement trouvée avec l'ID {id}"
                    );
                }

                return ServiceResponse.Success(
                    paymentMethod.ToDTO(),
                    "Méthode de paiement trouvée"
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

        public ServiceResponse AddPaymentMethod(PaymentMethodDto paymentMethodDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(paymentMethodDto.Label))
                {
                    return ServiceResponse.ValidationError(
                        "Le nom de la méthode de paiement est obligatoire"
                    );
                }

                // Vérifier doublon
                var exists = _context.PaymentMethods.Any(p => p.Label.ToLower() == paymentMethodDto.Label.ToLower());
                if (exists)
                {
                    return ServiceResponse.DuplicateEntry(
                        "Une méthode de paiement avec ce nom existe déjà"
                    );
                }

                var paymentMethod = paymentMethodDto.ToEntity();
                paymentMethod.IsActive = true; // Active by default

                _context.PaymentMethods.Add(paymentMethod);
                _context.SaveChanges();

                paymentMethodDto.Id = paymentMethod.Id;

                return ServiceResponse.Success(
                    paymentMethodDto,
                    "Méthode de paiement ajoutée avec succès"
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

        public ServiceResponse UpdatePaymentMethod(PaymentMethodDto paymentMethodDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(paymentMethodDto.Label))
                {
                    return ServiceResponse.ValidationError(
                        "Le nom de la méthode de paiement est obligatoire"
                    );
                }

                var paymentMethod = _context.PaymentMethods.Find(paymentMethodDto.Id);

                if (paymentMethod == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucune méthode de paiement trouvée avec l'ID {paymentMethodDto.Id}"
                    );
                }

                // Vérifier doublon
                var exists = _context.PaymentMethods.Any(p => 
                    p.Label.ToLower() == paymentMethodDto.Label.ToLower() && 
                    p.Id != paymentMethodDto.Id);
                if (exists)
                {
                    return ServiceResponse.DuplicateEntry(
                        "Une autre méthode de paiement utilise déjà ce nom"
                    );
                }

                paymentMethod.Label = paymentMethodDto.Label;
                paymentMethod.IsActive = paymentMethodDto.IsActive;

                _context.SaveChanges();

                return ServiceResponse.Success(
                    true,
                    "Méthode de paiement mise à jour avec succès"
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

        public ServiceResponse DeletePaymentMethod(int id)
        {
            try
            {
                var paymentMethod = _context.PaymentMethods.Find(id);

                if (paymentMethod == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucune méthode de paiement trouvée avec l'ID {id}"
                    );
                }

                // Check if payment method is used in any payments
                var isUsed = _context.Payments.Any(p => p.PaymentMethod == paymentMethod.Label);
                if (isUsed)
                {
                    return ServiceResponse.Error(
                        ServiceResultCode.BusinessRuleViolation,
                        "Cette méthode de paiement est utilisée dans des paiements. Suppression impossible."
                    );
                }

                _context.PaymentMethods.Remove(paymentMethod);
                _context.SaveChanges();

                return ServiceResponse.Success(
                    true,
                    "Méthode de paiement supprimée avec succès"
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

        public ServiceResponse SearchPaymentMethods(string searchTerm)
        {
            try
            {
                var query = _context.PaymentMethods.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(p => p.Label.ToLower().Contains(searchTerm));
                }

                var paymentMethods = query
                    .OrderBy(p => p.Label)
                    .ToList()
                    .Select(p => p.ToDTO())
                    .ToList();

                return ServiceResponse.Success(
                    paymentMethods,
                    $"{paymentMethods.Count} méthode(s) de paiement trouvée(s)"
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

        public ServiceResponse ToggleActiveStatus(int id)
        {
            try
            {
                var paymentMethod = _context.PaymentMethods.Find(id);

                if (paymentMethod == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucune méthode de paiement trouvée avec l'ID {id}"
                    );
                }

                paymentMethod.IsActive = !(paymentMethod.IsActive ?? false);
                _context.SaveChanges();

                string status = paymentMethod.IsActive == true ? "activée" : "désactivée";
                return ServiceResponse.Success(
                    true,
                    $"Méthode de paiement {status} avec succès"
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

