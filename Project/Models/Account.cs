/// <summary>
/// Модель аккаунта согласно БД
/// </summary>
public class Account
{
    public int AccountId { get; set; }
    public int UserId { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
