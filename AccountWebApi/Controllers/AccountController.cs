using AccountWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountWebApi.Controllers
{
    // Controllers/AccountsController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult CreateAccount(int customerId)
        {
            var account = _accountService.CreateAccount(customerId);
            return Ok(account);
        }

        [HttpGet("{accountId}")]
        public IActionResult GetAccount(int accountId)
        {
            var account = _accountService.GetAccount(accountId);
            return Ok(account);
        }
    }

}
