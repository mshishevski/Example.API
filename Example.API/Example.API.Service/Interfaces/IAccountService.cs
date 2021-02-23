using Example.API.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.API.Service.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetFirstUser();
        Task<List<Account>> GetAccountByName(string name);
    }
}
