/// <summary>
/// Сервис для управления кредитами
/// </summary>
public class LoanService : ILoanService
{
    private readonly OnlineBankContext _context;

    /// <summary>
    /// Инициализирует новый экземпляр класса с указанным контекстом базы данных
    /// </summary>
    public LoanService(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получает кредит по его идентификатору
    /// </summary>
    public Loan GetLoanById(int loanId) => _context.Loans.Find(loanId);

    /// <summary>
    /// Получает список кредитов, связанных с указанным идентификатором пользователя
    /// </summary>
    public IEnumerable<Loan> GetLoansByUserId(int userId) => 
        _context.Loans.Where(l => l.UserId == userId).ToList();

    /// <summary>
    /// Создает новый кредит
    /// </summary>
    public void CreateLoan(Loan loan)
    {
        _context.Loans.Add(loan);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновляет существующий кредит
    /// </summary>
    public void UpdateLoan(Loan loan)
    {
        _context.Loans.Update(loan);
        _context.SaveChanges();
    }

    /// <summary>
    /// Удаляет кредит по его идентификатору.
    /// </summary>
    public void DeleteLoan(int loanId)
    {
        var loan = _context.Loans.Find(loanId);
        if (loan != null)
        {
            _context.Loans.Remove(loan);
            _context.SaveChanges();
        }
    }
}
