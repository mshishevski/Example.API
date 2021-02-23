using Example.API.DataAccess.Interfaces;
using Example.API.DataAccess.Models;
using Example.API.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.API.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<List<Account>> GetAccountByName(string name)
        {
            name = name.ToLower(); // "martin == MARTIN"
            var accounts = await _accountRepository.GetByName(name);
            return accounts;
        }

        public async Task<Account> GetFirstUser()
        {
            var account = await _accountRepository.GetAllAccounts();
            return account.FirstOrDefault();
        }
    }
}
