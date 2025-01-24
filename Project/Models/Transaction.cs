/// <summary>
/// Модель транзакции согласно БД
/// </summary>
public class Transaction
{
    public int TransactionId { get; set; }
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }
    public DateTime CreatedAt { get; set; }

    public Account Account { get; set; }
}
