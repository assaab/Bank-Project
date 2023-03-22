using Microsoft.AspNetCore.Mvc;
using TransactionWebApi.Interfaces;

namespace TransactionWebApi.Controllers
{
    // Controllers/TransactionsController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult CreateTransaction(int accountId, decimal amount)
        {
            var transaction = _transactionService.CreateTransaction(accountId, amount);
            return Ok(transaction);
        }

        [HttpGet("{accountId}")]
        public IActionResult GetTransactions(int accountId)
        {
            var transactions = _transactionService.GetTransactions(accountId);
            return Ok(transactions);
        }
    }

}
