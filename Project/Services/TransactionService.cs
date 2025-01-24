/// <summary>
/// Сервис для управления транзакциями
/// </summary>
public class TransactionService : ITransactionService
{
    private readonly OnlineBankContext _context;

    /// <summary>
    /// Инициализирует новый экземпляр класса с указанным контекстом базы данных
    /// </summary>
    public TransactionService(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получает транзакцию по ее идентификатору
    /// </summary>
    public Transaction GetTransactionById(int transactionId) => 
        _context.Transactions.Find(transactionId);

    /// <summary>
    /// Получает список транзакций, связанных с указанным идентификатором счета
    /// </summary>
    public IEnumerable<Transaction> GetTransactionsByAccountId(int accountId) => 
        _context.Transactions.Where(t => t.AccountId == accountId).ToList();

    /// <summary>
    /// Создает новую транзакцию
    /// </summary>
    public void CreateTransaction(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновляет существующую транзакцию
    /// </summary>
    public void UpdateTransaction(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        _context.SaveChanges();
    }

    /// <summary>
    /// Удаляет транзакцию по ее идентификатору
    /// </summary>
    public void DeleteTransaction(int transactionId)
    {
        var transaction = _context.Transactions.Find(transactionId);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }
    }
}
