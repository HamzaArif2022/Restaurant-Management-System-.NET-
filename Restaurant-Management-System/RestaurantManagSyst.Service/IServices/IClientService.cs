using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IClientService
    {
        ServiceResponse GetAllClients();
        ServiceResponse GetClientById(int id);
        ServiceResponse AddClient(ClientDTO clientDto);
        ServiceResponse UpdateClient(ClientDTO clientDto);
        ServiceResponse DeleteClient(int id);
        ServiceResponse SearchClients(string searchTerm);
    }
}
