public interface ITransactionService
{
    Transaction GetTransactionById(int transactionId);
    IEnumerable<Transaction> GetTransactionsByAccountId(int accountId);
    void CreateTransaction(Transaction transaction);
    void UpdateTransaction(Transaction transaction);
    void DeleteTransaction(int transactionId);
}
