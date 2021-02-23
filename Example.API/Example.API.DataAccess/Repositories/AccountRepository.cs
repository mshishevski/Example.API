using Example.API.DataAccess.Containers;
using Example.API.DataAccess.Interfaces;
using Example.API.DataAccess.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.API.DataAccess.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private readonly AccountContainer _accountContainer;
        private readonly IConfiguration _configuration;
        public AccountRepository(AccountContainer accountContainer,
                                 IConfiguration configuration) : base(accountContainer, configuration)
        {
            _accountContainer = accountContainer;
            _configuration = configuration;
        }

        public Task<List<Account>> GetAllAccounts() => GetAll();

        public async Task<List<Account>> GetByName(string name)
        {
            List<Account> accounts = new List<Account>();
            using (FeedIterator<Account> setIterator = _accountContainer.GetItemLinqQueryable<Account>()
                      .Where(x => x.name == name)
                      .ToFeedIterator<Account>())
            {
                //Asynchronous query execution
                while (setIterator.HasMoreResults)
                {
                    foreach (var item in await setIterator.ReadNextAsync())
                    {
                        accounts.Add(item);
                    }
                }

                return accounts;
            }
        }
    }
}
