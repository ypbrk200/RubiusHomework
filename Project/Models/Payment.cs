/// <summary>
/// Модель платежа согласно БД
/// </summary>
public class Payment
{
    public int PaymentId { get; set; }
    public int LoanId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    public Loan Loan { get; set; }
}
