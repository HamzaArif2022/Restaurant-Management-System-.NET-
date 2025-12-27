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
    public class EmployeeService : IEmployeeService
    {
        private readonly RestaurantManagementEntities _context;

        public EmployeeService()
        {
            _context = new RestaurantManagementEntities();
        }

        public ServiceResponse GetAllEmployees()
        {
            try
            {
                var employees = _context.Employees
                    .OrderBy(e => e.Name)
                    .ToList()
                    .Select(e => e.ToDTO())
                    .ToList();

                return ServiceResponse.Success(
                    employees,
                    $"{employees.Count} employé(s) trouvé(s)"
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

        public ServiceResponse GetEmployeeById(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun employé trouvé avec l'ID {id}"
                    );
                }

                return ServiceResponse.Success(
                    employee.ToDTO(),
                    "Employé trouvé"
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

        public ServiceResponse AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(employeeDto.Name))
                {
                    return ServiceResponse.ValidationError(
                        "Le nom de l'employé est obligatoire"
                    );
                }

                if (string.IsNullOrWhiteSpace(employeeDto.Role))
                {
                    return ServiceResponse.ValidationError(
                        "Le rôle de l'employé est obligatoire"
                    );
                }

                // Vérifier doublon email
                if (!string.IsNullOrEmpty(employeeDto.Email))
                {
                    var exists = _context.Employees.Any(e => e.Email == employeeDto.Email);
                    if (exists)
                    {
                        return ServiceResponse.DuplicateEntry(
                            "Un employé avec cet email existe déjà"
                        );
                    }
                }

                var employee = employeeDto.ToEntity();
                employee.HireDate = employeeDto.HireDate ?? DateTime.Now.Date;

                // Hash password if provided
                if (!string.IsNullOrWhiteSpace(employeeDto.Password))
                {
                    employee.PasswordHash = HashPassword(employeeDto.Password);
                }

                _context.Employees.Add(employee);
                _context.SaveChanges();

                employeeDto.Id = employee.Id;

                return ServiceResponse.Success(
                    employeeDto,
                    "Employé ajouté avec succès"
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

        public ServiceResponse UpdateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(employeeDto.Name))
                {
                    return ServiceResponse.ValidationError(
                        "Le nom de l'employé est obligatoire"
                    );
                }

                if (string.IsNullOrWhiteSpace(employeeDto.Role))
                {
                    return ServiceResponse.ValidationError(
                        "Le rôle de l'employé est obligatoire"
                    );
                }

                var employee = _context.Employees.Find(employeeDto.Id);

                if (employee == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun employé trouvé avec l'ID {employeeDto.Id}"
                    );
                }

                // Vérifier doublon email
                if (!string.IsNullOrEmpty(employeeDto.Email))
                {
                    var exists = _context.Employees.Any(e => e.Email == employeeDto.Email && e.Id != employeeDto.Id);
                    if (exists)
                    {
                        return ServiceResponse.DuplicateEntry(
                            "Un autre employé utilise déjà cet email"
                        );
                    }
                }

                employee.Name = employeeDto.Name;
                employee.Role = employeeDto.Role;
                employee.Email = employeeDto.Email;
                employee.Phone = employeeDto.Phone;
                employee.HireDate = employeeDto.HireDate;

                // Update password only if provided
                if (!string.IsNullOrWhiteSpace(employeeDto.Password))
                {
                    employee.PasswordHash = HashPassword(employeeDto.Password);
                }

                _context.SaveChanges();

                return ServiceResponse.Success(
                    true,
                    "Employé mis à jour avec succès"
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

        public ServiceResponse DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    return ServiceResponse.NotFound(
                        $"Aucun employé trouvé avec l'ID {id}"
                    );
                }

                // Vérifier si l'employé a des commandes
                var hasOrders = _context.Orders.Any(o => o.EmployeeId == id);
                if (hasOrders)
                {
                    return ServiceResponse.Error(
                        ServiceResultCode.BusinessRuleViolation,
                        "Cet employé a des commandes associées. Suppression impossible."
                    );
                }

                _context.Employees.Remove(employee);
                _context.SaveChanges();

                return ServiceResponse.Success(
                    true,
                    "Employé supprimé avec succès"
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

        public ServiceResponse SearchEmployees(string searchTerm)
        {
            try
            {
                var query = _context.Employees.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(e =>
                        e.Name.ToLower().Contains(searchTerm) ||
                        e.Role.ToLower().Contains(searchTerm) ||
                        e.Phone.Contains(searchTerm) ||
                        e.Email.ToLower().Contains(searchTerm)
                    );
                }

                var employees = query
                    .OrderBy(e => e.Name)
                    .ToList()
                    .Select(e => e.ToDTO())
                    .ToList();

                return ServiceResponse.Success(
                    employees,
                    $"{employees.Count} employé(s) trouvé(s)"
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

