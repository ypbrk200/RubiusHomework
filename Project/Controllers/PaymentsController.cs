using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly OnlineBankContext _context;

    public PaymentsController(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все платежи
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
    {
        return await _context.Payments.Include(p => p.Loan).ToListAsync();
    }

    /// <summary>
    /// Получить конкретный платеж
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Payment>> GetPayment(int id)
    {
        var payment = await _context.Payments.Include(p => p.Loan)
                                              .FirstOrDefaultAsync(p => p.PaymentId == id);

        if (payment == null)
        {
            return NotFound();
        }

        return payment;
    }

    /// <summary>
    /// Получить платеж по кредиту
    /// </summary>
    [HttpGet("by-loan/{loanId}")]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsByLoan(int loanId)
    {
        var payments = await _context.Payments.Include(p => p.Loan)
                                              .Where(p => p.LoanId == loanId)
                                              .ToListAsync();

        if (!payments.Any())
        {
            return NotFound();
        }

        return payments;
    }

    /// <summary>
    /// Получить платежи по кредитам
    /// </summary>
    [HttpGet("loans")]
    public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
    {
        return await _context.Loans.ToListAsync();
    }

    /// <summary>
    /// Получить платежи по конкретному кредиту
    /// </summary>
    [HttpGet("loans/{id}")]
    public async Task<ActionResult<Loan>> GetLoan(int id)
    {
        var loan = await _context.Loans.FindAsync(id);

        if (loan == null)
        {
            return NotFound();
        }

        return loan;
    }

    /// <summary>
    /// Добавить платеж
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Payment>> PostPayment(Payment payment)
    {
        payment.PaymentDate = DateTime.UtcNow; // Установка даты платежа на текущее время
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, payment);
    }

    /// <summary>
    /// Изменить платеж
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPayment(int id, Payment payment)
    {
        if (id != payment.PaymentId)
        {
            return BadRequest();
        }

        _context.Entry(payment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PaymentExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    /// <summary>
    /// Удалить платеж
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null)
        {
            return NotFound();
        }

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PaymentExists(int id)
    {
        return _context.Payments.Any(p => p.PaymentId == id);
    }
}
