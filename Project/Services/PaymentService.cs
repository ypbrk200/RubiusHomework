/// <summary>
/// Сервис для управления платежами
/// </summary>
public class PaymentService : IPaymentService
{
    private readonly OnlineBankContext _context;

    /// <summary>
    /// Инициализирует новый экземпляр класса с указанным контекстом базы данных
    /// </summary>
    public PaymentService(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получает платеж по его идентификатору.
    /// </summary>
    public Payment GetPaymentById(int paymentId)
    {
        return _context.Payments.Find(paymentId);
    }

    /// <summary>
    /// Получает список платежей, связанных с указанным идентификатором займа
    /// </summary>
    public IEnumerable<Payment> GetPaymentsByLoanId(int loanId)
    {
        return _context.Payments.Where(p => p.LoanId == loanId).ToList();
    }

    /// <summary>
    /// Создает новый платеж
    /// </summary>
    public void CreatePayment(Payment payment)
    {
        _context.Payments.Add(payment);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновляет существующий платеж
    /// </summary>
    public void UpdatePayment(Payment payment)
    {
        _context.Payments.Update(payment);
        _context.SaveChanges();
    }

    /// <summary>
    /// Удаляет платеж по его идентификатору
    /// </summary>
    public void DeletePayment(int paymentId)
    {
        var payment = _context.Payments.Find(paymentId);
        if (payment != null)
        {
            _context.Payments.Remove(payment);
            _context.SaveChanges();
        }
    }
}
