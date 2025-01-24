public interface IAccountService
{
    Account GetAccountById(int accountId);
    IEnumerable<Account> GetAccountsByUserId(int userId);
    void CreateAccount(Account account);
    void UpdateAccount(Account account);
    void DeleteAccount(int accountId);
}
