using RestaurantManagSyst.Data;
using RestaurantManagSyst.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.Helpers
{
    
    public static class MappingHelper
    {
        // Clients Mapping
        public static ClientDTO ToDTO(this Clients entity)
        {
            if (entity == null) return null;

            return new ClientDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone,
                Email = entity.Email,
                JoinDate = entity.JoinDate,
                LoyaltyPoints = entity.LoyaltyPoints ?? 0
            };
        }

        public static Clients ToEntity(this ClientDTO dto)
        {
            if (dto == null) return null;

            return new Clients
            {
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                JoinDate = dto.JoinDate,
                LoyaltyPoints = dto.LoyaltyPoints
            };
        }

        // Order Mapping
        public static OrderDto ToDTO(this Orders entity)
        {
            if (entity == null) return null;

            return new OrderDto
            {
                Id = entity.Id,
                ClientId = entity.ClientId,
                ClientName = entity.Clients?.Name,
                EmployeeId = entity.EmployeeId,
                EmployeeName = entity.Employees?.Name,
                TableNumber = entity.TableNumber,
                OrderDate = entity.OrderDate,
                Status = entity.Status,
                Notes = entity.Notes,
                TotalAmount = entity.TotalAmount
            };
        }

        public static Orders ToEntity(this OrderDto dto)
        {
            if (dto == null) return null;

            return new Orders
            {
                Id = dto.Id,
                ClientId = dto.ClientId,
                EmployeeId = dto.EmployeeId,
                TableNumber = dto.TableNumber,
                OrderDate = dto.OrderDate,
                Status = dto.Status,
                Notes = dto.Notes,
                TotalAmount = dto.TotalAmount
            };
        }

        // MenuItem Mapping
        public static MenuItemDto ToDTO(this MenuItems entity)
        {
            if (entity == null) return null;

            return new MenuItemDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                BuyingPrice = entity.BuyingPrice,
                Category = entity.Category,
                PreparationTime = entity.PreparationTime,
                IsAvailable = entity.IsAvailable ?? true,
                Image = entity.Image
            };
        }

        public static MenuItems ToEntity(this MenuItemDto dto)
        {
            if (dto == null) return null;

            return new MenuItems
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                BuyingPrice = dto.BuyingPrice,
                Category = dto.Category,
                PreparationTime = dto.PreparationTime,
                IsAvailable = dto.IsAvailable,
                Image = dto.Image
            };
        }
    }
}
