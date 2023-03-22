using BankWebApi;
using Microsoft.AspNetCore.Authentication;
using Models;
using TransactionWebApi.Interfaces;

namespace TransactionWebApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BankContext _context;

        public TransactionService(BankContext context)
        {
            _context = context;
        }

        public Transaction CreateTransaction(int accountId, decimal amount)
        {
            var transaction = new Transaction { AccountID = accountId, Amount = amount, Date = DateTime.UtcNow };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return transaction;
        }

        public List<Transaction> GetTransactions(int accountId)
        {
            return _context.Transactions.Where(t => t.AccountID == accountId).ToList();
        }

        Transaction ITransactionService.CreateTransaction(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        List<Transaction> ITransactionService.GetTransactions(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
