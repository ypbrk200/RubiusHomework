/// <summary>
/// Сервис для управления аккаунтами
/// </summary>
public class AccountService : IAccountService
{
    private readonly OnlineBankContext _context;

    /// <summary>
    /// Инициализирует новый экземпляр класса с указанным контекстом базы данных
    /// </summary>
    public AccountService(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получает аккаунт по его идентификатору
    /// </summary>
    public Account GetAccountById(int accountId) => _context.Accounts.Find(accountId);

    /// <summary>
    /// Получает список аккаунтов, связанных с указанным идентификатором пользователя
    /// </summary>
    public IEnumerable<Account> GetAccountsByUserId(int userId) => 
        _context.Accounts.Where(a => a.UserId == userId).ToList();

    /// <summary>
    /// Создает новый аккаунт
    /// </summary>
    public void CreateAccount(Account account)
    {
        _context.Accounts.Add(account);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновляет существующий аккаунт
    /// </summary>
    public void UpdateAccount(Account account)
    {
        _context.Accounts.Update(account);
        _context.SaveChanges();
    }

    /// <summary>
    /// Удаляет аккаунт по его идентификатору
    /// </summary>
    public void DeleteAccount(int accountId)
    {
        var account = _context.Accounts.Find(accountId);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
    }
}
