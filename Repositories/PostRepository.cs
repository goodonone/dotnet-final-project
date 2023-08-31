using System.Linq;
using backend_api.Migrations;
using backend_api.Models;

namespace backend_api.Repositories;

public class PostRepository : IPostRepository
{
    private readonly PostDbContext _context;

    public PostRepository(PostDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Post> GetAllPosts()
    {
        return _context.Posts.ToList();
    }


    public Post CreatePost(Post newPost)
    {
        _context.Posts.Add(newPost);
        _context.SaveChanges();
        return newPost;
    }


    public Post? GetPostById(int postId)
    {
        return _context.Posts.SingleOrDefault(c => c.PostId == postId);
    }


    public IEnumerable<Post>GetAllPostsByUserId(int userId)
    {
        return _context.Posts.Where(p => p.UserId == userId);
    }


    public Post? UpdatePost(Post newPost)
    {
        var originalPost = _context.Posts.Find(newPost.PostId);
        if (originalPost != null)
        {
            originalPost.Chirp = newPost.Chirp;
            originalPost.ChirpDate = newPost.ChirpDate = DateTime.Now.ToString("dd MMMM yyyy");
            _context.SaveChanges();
        }
        return originalPost;
    }


    public void DeletePostById(int PostId)
    {
        var post = _context.Posts.Find(PostId);
        if (post != null)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Post> GetAllPostsById()
    {
        throw new NotImplementedException();
    }
}



