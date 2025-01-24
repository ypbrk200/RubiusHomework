/// <summary>
/// Модель кредита согласно БД
/// </summary>
public class Loan
{
    public int LoanId { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public decimal InterestRate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
