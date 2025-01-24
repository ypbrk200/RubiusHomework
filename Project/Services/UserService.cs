/// <summary>
/// Сервис для управления пользователями
/// </summary>
public class UserService : IUserService
{
    private readonly OnlineBankContext _context;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UserService"/> с указанным контекстом базы данных
    /// </summary>
    public UserService(OnlineBankContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получает пользователя по его идентификатору
    /// </summary>
    public User GetUserById(int userId) => 
        _context.Users.Find(userId);

    /// <summary>
    /// Получает всех пользователей
    /// </summary>
    public IEnumerable<User> GetAllUsers() => 
        _context.Users.ToList();

    /// <summary>
    /// Создает нового пользователя
    /// </summary>
    public void CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    /// <summary>
    /// Обновляет существующего пользователя
    /// </summary>
    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    /// <summary>
    /// Удаляет пользователя по его идентификатору
    /// </summary>
    public void DeleteUser(int userId)
    {
        var user = _context.Users.Find(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
