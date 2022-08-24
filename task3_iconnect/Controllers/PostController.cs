using Microsoft.AspNetCore.Mvc;
using task3_iconnect.repo;
using task3_iconnect.user.model;
using task3_iconnect.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace task3_iconnect.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   // [Authorize]
   // [Authorize(Roles = "Admin")]
    public class PostController : ControllerBase
    {

        private readonly IpostsRepo _postRepo;
        private readonly IMapper _mapper;


        public PostController(IpostsRepo postRepo, IMapper iMapper)
        {
            _postRepo = postRepo;
            _mapper = iMapper;
        }

        [HttpGet]
        //[ServiceFilter(typeof(Filters))]
        public async Task <List<PostView>> GetAll()
        {
            var posts = await _postRepo.GetAll<Post>();
            return  _mapper.Map<List<PostView>>(posts);
        }
       [HttpGet]
        public List<PostView> GetBySearch(int PageN, int pageSize, string phrase)
        {
            var response = _postRepo.searchPosts(PageN, pageSize, phrase);
            return _mapper.Map<List<Post>, List<PostView>>(response);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult <PostView>>Get(int id)
        {

            var post = _postRepo.Get<Post>(id);
            var post1 = _mapper.Map<PostView>(post);
            if (post == null)

                return  NotFound();
            return  post1;

        }
        [HttpDelete("{id}")]

        public async Task <ActionResult> Deletet(int id)
        {

            var user1 = _postRepo.Get<Post>(id);
            if (user1 == null)

                return NotFound();
            _postRepo.delete(id);
            return Ok();

        }
        [HttpPost]
        public async Task Create([FromBody] PostView PostV)
        {
            var post1 = _mapper.Map<Post>(PostV);
            // var post_ = _postRepo.Get<Post>(post1.Id);
            // await _postRepo.Add(post1);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("userID")?.Value;

            post1.IdUser = Convert.ToInt32(userId);
            await _postRepo.Add( post1, post1.IdUser);


        }
        [HttpPut]
        public async Task Update(PostView postV)
        {
            var post1 = _mapper.Map<Post>(postV);
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("userID")?.Value;

            post1.IdUser = Convert.ToInt32(userId);
            await _postRepo.update(_mapper.Map<Post>(postV), post1.IdUser);



        }


    }
}

