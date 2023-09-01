using System.Collections.Generic;
using backend_api.Models;

namespace backend_api.Repositories;
public interface IPostRepository
{
    IEnumerable<Post> GetAllPosts();
    
    IEnumerable<Post> GetAllPostsByUserId(int userId);
    Post? GetPostById(int postId);
    Post CreatePost(Post newPost);
    Post? UpdatePost(Post newPost);
    void DeletePostById(int postId);

}