
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        if (await GetUserByEmailAsync(model.Email) != null || await GetUserByUserNameAsync(model.UserName) != null)
            return false;

        var entity = new UserEntity
        {
            Email = model.Email,
            UserName = model.UserName,
            Password = model.Password,
            DateCreated = DateTime.Now
        };

        var passwordHasher = new PasswordHasher<UserEntity>();
        entity.Password = passwordHasher.HashPassword(entity, model.Password);

        _context.Users.Add(entity);
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }

    private async Task<UserEntity> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
    }

    public async Task<UserEntity> GetUserByUserNameAsync(string userName)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.UserName.ToLower() == userName.ToLower());
    }

    public async Task<UserDetail> GetUserByIdAsync(int userId)
    {
        var entity = await _context.Users.FindAsync(userId);
        if (entity is null)
            return null;

        var userDetail = new UserDetail
        {
            Id = entity.Id,
            Email = entity.Email,
            Username = entity.UserName,
            FirstName = entity.FirstName,
            Lastname = entity.LastName,
            DateCreated = entity.DateCreated
        };

        return userDetail;
    }
}
