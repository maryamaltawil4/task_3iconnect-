using Microsoft.AspNetCore.Mvc;
using task3_iconnect.repo;
using task3_iconnect.user.model;

namespace task3_iconnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IpostsRepo _postRepo;

        public PostController(IpostsRepo postRepo)
        {
            _postRepo = postRepo;
        }

        [HttpGet]
        [ServiceFilter(typeof(Filters))]
        public ActionResult<List<Post>> GetAll()
        {
            return _postRepo.GetAll();


        }
        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {

            var post = _postRepo.Get(id);
            if (post == null)

                return NotFound();
            return post;

        }
        [HttpDelete("{id}")]

        public ActionResult Deletet(int id)
        {

            var user1 = _postRepo.Get(id);
            if (user1 == null)

                return NotFound();
            _postRepo.delete(id);
            return Ok();

        }
        [HttpPost]
        public ActionResult Create([FromBody] Post post)
        {
            try
            {
                _postRepo.Add(post);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
        [HttpPut]
        public ActionResult Update(Post post)
        {
           
            _postRepo.Update(post);
            return Ok();


        }


    }
}

