using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly OnlineBankContext _context;

    public AccountsController(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все аккаунты
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
    {
        return await _context.Accounts.Include(a => a.User).ToListAsync();
    }

    /// <summary>
    /// Получить аккаунт по Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetAccount(int id)
    {
        var account = await _context.Accounts
                                     .Include(a => a.User)
                                     .Include(a => a.Transactions)
                                     .FirstOrDefaultAsync(a => a.AccountId == id);

        if (account == null)
        {
            return NotFound();
        }

        return account;
    }

    /// <summary>
    /// Получить транзакции аккаунта
    /// </summary>
    [HttpGet("{id}/transactions")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetAccountTransactions(int id)
    {
        var account = await _context.Accounts.Include(a => a.Transactions)
                                             .FirstOrDefaultAsync(a => a.AccountId == id);

        if (account == null)
        {
            return NotFound();
        }

        return account.Transactions.ToList();
    }

    /// <summary>
    /// Получить кредиты аккаунта
    /// </summary>
    [HttpGet("{id}/user/loans")]
    public async Task<ActionResult<IEnumerable<Loan>>> GetUserLoansByAccount(int id)
    {
        var account = await _context.Accounts.Include(a => a.User)
                                             .FirstOrDefaultAsync(a => a.AccountId == id);

        if (account == null)
        {
            return NotFound();
        }

        var loans = await _context.Loans.Where(l => l.UserId == account.User.UserId).ToListAsync();

        return loans;
    }

    /// <summary>
    /// Создать аккаунт
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Account>> PostAccount(Account account)
    {
        // Установить дату создания
        account.CreatedAt = DateTime.UtcNow; 
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAccount), new { id = account.AccountId }, account);
    }

    /// <summary>
    /// Изменить аккаунт
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAccount(int id, Account account)
    {
        if (id != account.AccountId)
        {
            return BadRequest();
        }

        _context.Entry(account).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AccountExists(id))
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
    /// Удалить аккаунт
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null)
        {
            return NotFound();
        }

        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AccountExists(int id)
    {
        return _context.Accounts.Any(e => e.AccountId == id);
    }
}
