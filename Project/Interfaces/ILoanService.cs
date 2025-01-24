public interface ILoanService
{
    Loan GetLoanById(int loanId);
    IEnumerable<Loan> GetLoansByUserId(int userId);
    void CreateLoan(Loan loan);
    void UpdateLoan(Loan loan);
    void DeleteLoan(int loanId);
}
