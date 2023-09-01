using backend_api.Models;
using backend_api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase 
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _postRepository;

        public PostController(ILogger<PostController> logger, IPostRepository repository)
        {
            _logger = logger;
            _postRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts() 
        {
            return Ok(_postRepository.GetAllPosts());
        }

        [HttpGet]
        [Route("{userId:int}/posts")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Post>> GetPostsByUserId(int userId) 
        {

            return Ok(_postRepository.GetAllPostsByUserId(userId));
            // var post = _postRepository.GetAllPostsByUserId(userId);
            // if (post == null) {
            //     return NotFound();
            // }
            // return Ok(post);
        }

        [HttpGet]
        [Route("{PostId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Post> GetPostById(int postId) 
        {
            var post = _postRepository.GetPostById(postId);
            if (post == null) {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Post> CreatePost(Post post) 
        {
            if (!ModelState.IsValid || post == null) {
                return BadRequest();
            }
            var newPost = _postRepository.CreatePost(post);
            return Created(nameof(GetPostById), newPost);
        }

        [HttpPut]
        [Route("{PostId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            public ActionResult<Post> EditPost(Post post) 
        {
            if (!ModelState.IsValid || post == null) {
                return BadRequest();
            }
            return Ok(_postRepository.UpdatePost(post));
        }

        [HttpDelete]
        [Route("{PostId:int}")]
        public ActionResult DeletePost(int postId) 
        {
            _postRepository.DeletePostById(postId); 
            return NoContent();
        }
    }
}