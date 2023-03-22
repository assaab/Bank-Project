using Models;
using System.Security.Principal;

namespace AccountWebApi.Interfaces
{
    public interface IAccountService
    {
        Account CreateAccount(int customerId);
        Account GetAccount(int accountId);
    }
}
