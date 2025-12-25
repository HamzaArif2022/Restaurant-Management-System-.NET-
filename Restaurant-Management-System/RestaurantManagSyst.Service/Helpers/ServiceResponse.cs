using RestaurantManagSyst.Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.Helpers
{
   
    public class ServiceResponse
    {
        public ServiceResultCode Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        // Constructeurs
        public ServiceResponse()
        {
        }

        public ServiceResponse(ServiceResultCode code, string message, object data = null)
        {
            Code = code;
            Message = message;
            Data = data;
        }

      
        public static ServiceResponse Success(object data, string message = "Opération réussie")
        {
            return new ServiceResponse
            {
                Code = ServiceResultCode.Success,
                Message = message,
                Data = data
            };
        }

        public static ServiceResponse Error(ServiceResultCode code, string message)
        {
            return new ServiceResponse
            {
                Code = code,
                Message = message,
                Data = null
            };
        }

        public static ServiceResponse NotFound(string message = "Élément introuvable")
        {
            return new ServiceResponse
            {
                Code = ServiceResultCode.NotFound,
                Message = message,
                Data = null
            };
        }

        public static ServiceResponse ValidationError(string message)
        {
            return new ServiceResponse
            {
                Code = ServiceResultCode.ValidationError,
                Message = message,
                Data = null
            };
        }

        public static ServiceResponse DuplicateEntry(string message)
        {
            return new ServiceResponse
            {
                Code = ServiceResultCode.DuplicateEntry,
                Message = message,
                Data = null
            };
        }

        
        public bool IsSuccess => Code == ServiceResultCode.Success;
    }
}
