
public interface IPostService
{
    Task<bool> CreatePostAsync(PostCreate request);
    Task<IEnumerable<PostListItem>> GetAllPostsAsync();
}
