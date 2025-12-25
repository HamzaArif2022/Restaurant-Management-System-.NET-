using RestaurantManagSyst.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IAuthService
    {
        ServiceResponse Login(string username, string password);
        ServiceResponse ChangePassword(int userId, string oldPassword, string newPassword);
    }
}
