
public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);

    Task<UserDetail> GetUserByIdAsync(int userId);
}
