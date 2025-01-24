public interface IPaymentService
{
    Payment GetPaymentById(int paymentId);
    IEnumerable<Payment> GetPaymentsByLoanId(int loanId);
    void CreatePayment(Payment payment);
    void UpdatePayment(Payment payment);
    void DeletePayment(int paymentId);
}
