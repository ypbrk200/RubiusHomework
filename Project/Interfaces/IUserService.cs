public interface IUserService
{
    User GetUserById(int userId);
    IEnumerable<User> GetAllUsers();
    void CreateUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}
