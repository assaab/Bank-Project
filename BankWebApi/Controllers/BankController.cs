using Microsoft.AspNetCore.Mvc;
using Models;

namespace BankWebApi.Controllers
{
    public class BankController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _accountsApiBaseUrl = "https://ocalhost:7070/api/account";
        private readonly string _transactionsApiBaseUrl = "https://ocalhost:7178/api/transaction";

        public BankController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost("OpenAccount")]
        public async Task<IActionResult> OpenAccount(int customerID, decimal initialCredit)
        {
            var accountResponse = await _httpClient.PostAsJsonAsync($"{_accountsApiBaseUrl}?customerId={customerID}", new { });
            if (!accountResponse.IsSuccessStatusCode)
            {
                return NotFound();
            }
            var account = await accountResponse.Content.ReadFromJsonAsync<Account>();

            if (initialCredit > 0)
            {
                await _httpClient.PostAsJsonAsync($"{_transactionsApiBaseUrl}?accountId={account.ID}&amount={initialCredit}", new { });
            }

            return Ok(account.ID);
        }

        [HttpGet("UserInfo/{customerID}")]
        public async Task<IActionResult> GetUserInfo(int customerID)
        {
            var accountsResponse = await _httpClient.GetAsync($"{_accountsApiBaseUrl}/customer/{customerID}");
            if (!accountsResponse.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var accounts = await accountsResponse.Content.ReadFromJsonAsync<List<Account>>();

            var customerInfo = new
            {
                CustomerID = customerID,
                Accounts = accounts.Select(async a =>
                {
                    var transactionsResponse = await _httpClient.GetAsync($"{_transactionsApiBaseUrl}/{a.ID}");
                    var transactions = await transactionsResponse.Content.ReadFromJsonAsync<List<Transaction>>();
                    return new
                    {
                        a.ID,
                        a.Balance,
                        Transactions = transactions
                    };
                }).Select(t => t.Result).ToList()
            };

            return Ok(customerInfo);
        }

    }
}