
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class PostService : IPostService
{
    private readonly ApplicationDbContext _context;
    private readonly int _userId;

    public PostService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
    {
        var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        var value = userClaims.FindFirst("Id")?.Value;
        var validId = int.TryParse(value, out _userId);
        if (!validId)
            throw new Exception("Attempted to build PostService without User Id claim.");

        _context = context;
    }

    public async Task<bool> CreatePostAsync(PostCreate request)
    {
        var postEntity = new PostEntity
        {
            Title = request.Title,
            Text = request.Text,
            PostDate = DateTimeOffset.Now,
            AuthorId = _userId
        };

        await _context.AddAsync(postEntity);

        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<IEnumerable<PostListItem>> GetAllPostsAsync()
    {
        var posts = await _context.Posts
            .Where(entity => entity.AuthorId == _userId)
            .Select(entity => new PostListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                PostDate = entity.PostDate
            })
            .ToListAsync();

        return posts;
    }
}
