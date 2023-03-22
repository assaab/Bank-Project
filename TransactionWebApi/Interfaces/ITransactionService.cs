using Models;

namespace TransactionWebApi.Interfaces
{
   
        public interface ITransactionService
        {
            Transaction CreateTransaction(int accountId, decimal amount);
            List<Transaction> GetTransactions(int accountId);
        }
    
}
