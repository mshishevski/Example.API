using Example.API.DataAccess.Models;
using Example.API.Persistence.Enums;

namespace Example.API.Persistence.DTOs
{
    public class AccountResponse : Account
    {
        public GenderEnum gender { get; set; }
    }
}
