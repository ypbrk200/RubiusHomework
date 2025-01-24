/// <summary>
/// Модель пользователя согласно БД
/// </summary>
public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Account> Accounts { get; set; }
    public ICollection<Loan> Loans { get; set; }
}
