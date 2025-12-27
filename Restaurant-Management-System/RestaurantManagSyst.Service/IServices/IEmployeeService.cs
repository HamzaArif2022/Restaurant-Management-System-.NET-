using RestaurantManagSyst.Service.DTOs;
using RestaurantManagSyst.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.IServices
{
    public interface IEmployeeService
    {
        ServiceResponse GetAllEmployees();
        ServiceResponse GetEmployeeById(int id);
        ServiceResponse AddEmployee(EmployeeDto employeeDto);
        ServiceResponse UpdateEmployee(EmployeeDto employeeDto);
        ServiceResponse DeleteEmployee(int id);
        ServiceResponse SearchEmployees(string searchTerm);
    }
}

