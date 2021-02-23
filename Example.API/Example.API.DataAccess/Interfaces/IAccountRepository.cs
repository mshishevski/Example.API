using Example.API.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.API.DataAccess.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccounts();
        Task<List<Account>> GetByName(string name);
    }
}
