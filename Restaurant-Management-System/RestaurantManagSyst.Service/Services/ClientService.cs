using RestaurantManagSyst.Data;
using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Enums;
using RestaurantManagSyst.Service.Helpers;
using RestaurantManagSyst.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly RestaurantManagementEntities _context;

        public ClientService()
        {
            _context = new RestaurantManagementEntities();
        }

        public ServiceResponse GetAllClients()
        {
            try
            {
                var clients = _context.Clients
                    .OrderBy(c => c.Name)
                    .ToList()
                    .Select(c => c.ToDTO())
                    .ToList();

                return ServiceResponse.Success(
                    clients,
                    $"{clients.Count} client(s) trouvé(s)"
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

        public ServiceResponse GetClientById(int id)
        {
            try
            {
                var client = _context.Clients.Find(id);

                if (client == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun client trouvé avec l'ID {id}"
                    );
                }

                return ServiceResponse.Success(
                    client.ToDTO(),
                    "Client trouvé"
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

        public ServiceResponse AddClient(ClientDTO clientDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(clientDto.Name))
                {
                    return ServiceResponse.ValidationError(
                        "Le nom du client est obligatoire"
                    );
                }

                // Vérifier doublon email
                if (!string.IsNullOrEmpty(clientDto.Email))
                {
                    var exists = _context.Clients.Any(c => c.Email == clientDto.Email);
                    if (exists)
                    {
                        return ServiceResponse.DuplicateEntry(
                            "Un client avec cet email existe déjà"
                        );
                    }
                }

                var client = clientDto.ToEntity();
                client.JoinDate = DateTime.Now.Date;
                client.LoyaltyPoints = 0;

                _context.Clients.Add(client);
                _context.SaveChanges();

                clientDto.Id = client.Id;

                return ServiceResponse.Success(
                    clientDto,
                    "Client ajouté avec succès"
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

        public ServiceResponse UpdateClient(ClientDTO clientDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(clientDto.Name))
                {
                    return ServiceResponse.ValidationError(
                        "Le nom du client est obligatoire"
                    );
                }

                var client = _context.Clients.Find(clientDto.Id);

                if (client == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun client trouvé avec l'ID {clientDto.Id}"
                    );
                }

                // Vérifier doublon email
                if (!string.IsNullOrEmpty(clientDto.Email))
                {
                    var exists = _context.Clients.Any(c => c.Email == clientDto.Email && c.Id != clientDto.Id);
                    if (exists)
                    {
                        return ServiceResponse.DuplicateEntry(
                            "Un autre client utilise déjà cet email"
                        );
                    }
                }

                client.Name = clientDto.Name;
                client.Phone = clientDto.Phone;
                client.Email = clientDto.Email;
                client.LoyaltyPoints = clientDto.LoyaltyPoints;

                _context.SaveChanges();

                return ServiceResponse.Success(
                    true,
                    "Client mis à jour avec succès"
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

        public ServiceResponse DeleteClient(int id)
        {
            try
            {
                var client = _context.Clients.Find(id);

                if (client == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun client trouvé avec l'ID {id}"
                    );
                }

                // Vérifier si le client a des commandes
                var hasOrders = _context.Orders.Any(o => o.ClientId == id);
                if (hasOrders)
                {
                    return ServiceResponse.Error(
                        ServiceResultCode.BusinessRuleViolation,
                        "Ce client a des commandes associées. Suppression impossible."
                    );
                }

                _context.Clients.Remove(client);
                _context.SaveChanges();

                return ServiceResponse.Success(
                    true,
                    "Client supprimé avec succès"
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

        public ServiceResponse SearchClients(string searchTerm)
        {
            try
            {
                var query = _context.Clients.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(c =>
                        c.Name.ToLower().Contains(searchTerm) ||
                        c.Phone.Contains(searchTerm) ||
                        c.Email.ToLower().Contains(searchTerm)
                    );
                }

                var clients = query
                    .OrderBy(c => c.Name)
                    .ToList()
                    .Select(c => c.ToDTO())
                    .ToList();

                return ServiceResponse.Success(
                    clients,
                    $"{clients.Count} client(s) trouvé(s)"
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
