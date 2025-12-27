using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagSyst.Service.Enums
{
    public enum ServiceResultCode
    {
        Success,
        NotFound,
        ValidationError,
        DuplicateEntry,
        DatabaseError,
        Unauthorized,
        BusinessRuleViolation,
        InvalidOperation
    }
}
