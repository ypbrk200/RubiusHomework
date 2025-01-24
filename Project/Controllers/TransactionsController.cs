using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly OnlineBankContext _context;

    public TransactionsController(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все транзакции
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
    {
        return await _context.Transactions.Include(t => t.Account).ToListAsync();
    }

    /// <summary>
    /// Получить транзакцию
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetTransaction(int id)
    {
        var transaction = await _context.Transactions
                                        .Include(t => t.Account)
                                        .FirstOrDefaultAsync(t => t.TransactionId == id);

        if (transaction == null)
        {
            return NotFound();
        }

        return transaction;
    }

    /// <summary>
    /// Получить транзакции аккаунта
    /// </summary>
    [HttpGet("account/{accountId}")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsByAccount(int accountId)
    {
        var transactions = await _context.Transactions
                                          .Where(t => t.AccountId == accountId)
                                          .Include(t => t.Account)
                                          .ToListAsync();

        if (!transactions.Any())
        {
            return NotFound();
        }

        return transactions;
    }

    /// <summary>
    /// Получить транзакции пользователя
    /// </summary>
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsByUser(int userId)
    {
        var accountIds = await _context.Accounts.Where(a => a.UserId == userId)
                                                .Select(a => a.AccountId)
                                                .ToListAsync();

        var transactions = await _context.Transactions
                                          .Where(t => accountIds.Contains(t.AccountId))
                                          .Include(t => t.Account)
                                          .ToListAsync();

        if (!transactions.Any())
        {
            return NotFound();
        }

        return transactions;
    }

    /// <summary>
    /// Добавить транзакцию
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
    {
        // Устанавливаем дату создания
        transaction.CreatedAt = DateTime.UtcNow;
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionId }, transaction);
    }

    /// <summary>
    /// Изменить транзакцию
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
    {
        if (id != transaction.TransactionId)
        {
            return BadRequest();
        }

        _context.Entry(transaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {           
            throw;            
        }

        return NoContent();
    }

    /// <summary>
    /// Удалить транзакцию
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id); if (transaction == null) { return NotFound(); }
    }
}
