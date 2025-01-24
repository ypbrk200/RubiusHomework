using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly OnlineBankContext _context;

    public LoansController(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все кредиты
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
    {
        return await _context.Loans.Include(l => l.User)
                                    .Include(l => l.Payments)
                                    .ToListAsync();
    }

    /// <summary>
    /// Получить кредит по Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Loan>> GetLoan(int id)
    {
        var loan = await _context.Loans
                                  .Include(l => l.User)
                                  .Include(l => l.Payments)
                                  .FirstOrDefaultAsync(l => l.LoanId == id);

        if (loan == null)
        {
            return NotFound();
        }

        return loan;
    }

    /// <summary>
    /// Получить кредиты пользователя
    /// </summary>
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<Loan>>> GetLoansByUser(int userId)
    {
        var loans = await _context.Loans
                                   .Where(l => l.UserId == userId)
                                   .Include(l => l.User)
                                   .Include(l => l.Payments)
                                   .ToListAsync();

        if (!loans.Any())
        {
            return NotFound();
        }

        return loans;
    }

    /// <summary>
    /// Получить кредит по платежу
    /// </summary>
    [HttpGet("{id}/payments")]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsByLoan(int id)
    {
        var loan = await _context.Loans
                                  .Include(l => l.Payments)
                                  .FirstOrDefaultAsync(l => l.LoanId == id);

        if (loan == null)
        {
            return NotFound();
        }

        return loan.Payments.ToList();
    }

    /// <summary>
    /// Добавить кредит
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Loan>> PostLoan(Loan loan)
    {
        loan.CreatedAt = DateTime.UtcNow; // Установить дату создания
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLoan), new { id = loan.LoanId }, loan);
    }

    /// <summary>
    /// Изменить кредит
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLoan(int id, Loan loan)
    {
        if (id != loan.LoanId)
        {
            return BadRequest();
        }

        _context.Entry(loan).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LoanExists(id))
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
    /// Удалить кредит
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoan(int id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan == null)
        {
            return NotFound();
        }

        _context.Loans.Remove(loan);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LoanExists(int id)
    {
        return _context.Loans.Any(l => l.LoanId == id);
    }
}
