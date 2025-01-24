using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly OnlineBankContext _context;

    public UsersController(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    /// <summary>
    /// Получить пользователя
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    /// <summary>
    /// Получить кредиты пользователя
    /// </summary>
    [HttpGet("{id}/loans")]
    public async Task<ActionResult<IEnumerable<Loan>>> GetUserLoans(int id)
    {
        var user = await _context.Users.Include(u => u.Loans)
                                        .FirstOrDefaultAsync(u => u.UserId == id);

        if (user == null)
        {
            return NotFound();
        }

        return user.Loans.ToList();
    }
    
    /// <summary>
    /// Получить платежи пользователя
    /// </summary>
    [HttpGet("{id}/payments")]
    public async Task<ActionResult<IEnumerable<Payment>>> GetUserPayments(int id)
    {
        var payments = await _context.Payments.Include(p => p.Loan)
                                               .Where(p => p.Loan.UserId == id)
                                               .ToListAsync();

        if (!payments.Any())
        {
            return NotFound();
        }

        return payments;
    }

    /// <summary>
    /// Создать пользователя
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        user.CreatedAt = DateTime.UtcNow; // Установить дату создания
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }

    /// <summary>
    /// Изменить пользователя
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
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
    /// Удалить пользователя
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(int id)
    {
        return _context.Users.Any(e => e.UserId == id);
    }
}
