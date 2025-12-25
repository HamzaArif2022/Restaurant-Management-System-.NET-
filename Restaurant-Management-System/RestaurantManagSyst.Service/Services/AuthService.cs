using RestaurantManagSyst.Data;
using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Enums;
using RestaurantManagSyst.Service.Helpers;
using RestaurantManagSyst.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.Services
{

    public class AuthService : IAuthService
    {
        private readonly RestaurantManagementEntities _context;

        public AuthService()
        {
            _context = new RestaurantManagementEntities();
        }

        public ServiceResponse Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    return ServiceResponse.ValidationError(
                        "Le nom d'utilisateur et le mot de passe sont obligatoires"
                    );
                }

                var passwordHash = HashPassword(password);

                var user = _context.Users.FirstOrDefault(u =>
                    u.Username == username &&
                    u.PasswordHash == passwordHash &&
                    u.IsActive == true
                );

                if (user == null)
                {
                    return ServiceResponse.Error(
                        ServiceResultCode.Unauthorized,
                        "Nom d'utilisateur ou mot de passe incorrect"
                    );
                }

                // Mettre à jour LastLogin
                user.LastLogin = DateTime.Now;
                _context.SaveChanges();

                var userDto = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt,
                    LastLogin = user.LastLogin,
                    IsActive = user.IsActive
                };

                return ServiceResponse.Success(
                    userDto,
                    "Connexion réussie"
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

        public ServiceResponse ChangePassword(int userId, string oldPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
                {
                    return ServiceResponse.ValidationError(
                        "L'ancien et le nouveau mot de passe sont obligatoires"
                    );
                }

                if (newPassword.Length < 6)
                {
                    return ServiceResponse.ValidationError(
                        "Le mot de passe doit contenir au moins 6 caractères"
                    );
                }

                var user = _context.Users.Find(userId);

                if (user == null)
                {
                    return ServiceResponse.NotFound("Utilisateur introuvable");
                }

                var oldPasswordHash = HashPassword(oldPassword);
                if (user.PasswordHash != oldPasswordHash)
                {
                    return ServiceResponse.Error(
                        ServiceResultCode.Unauthorized,
                        "Ancien mot de passe incorrect"
                    );
                }

                user.PasswordHash = HashPassword(newPassword);
                _context.SaveChanges();

                return ServiceResponse.Success(
                    true,
                    "Mot de passe modifié avec succès"
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

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString();
            }
        }
    }
}
