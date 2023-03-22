using AccountWebApi.Interfaces;
using BankWebApi;
using Microsoft.AspNetCore.Authentication;
using Models;

namespace AccountWebApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly BankContext _context;

        public AccountService(BankContext context)
        {
            _context = context;
        }

        public Account CreateAccount(int customerId)
        {
            var account = new Account { ID = customerId };
            _context.Accounts.Add(account);
            _context.SaveChanges();

            return account;
        }

        public Account GetAccount(int accountId)
        {
            return _context.Accounts.SingleOrDefault(a => a.ID == accountId);
        }
    }

}
