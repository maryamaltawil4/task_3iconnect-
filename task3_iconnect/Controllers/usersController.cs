using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task3_iconnect.repo;
using task3_iconnect.user.model;
using task3_iconnect.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace task3_iconnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class UserConroller : ControllerBase

    {
        private  IUserInterface _userRepo;
        private readonly IMapper _mapper;


        public UserConroller(IUserInterface userRepo, IMapper iMapper)
        {
            _userRepo = userRepo;
            _mapper = iMapper;
        }

        [HttpGet]
        //[ServiceFilter(typeof(Filters))]
        public  async Task <List<UsersView>> GetAll()
        {

            var temp= await _userRepo.GetAll<users>();
            return _mapper.Map<List<UsersView>>(temp);


        }
        [HttpGet("{id}")]
       
        public UsersView Get(int id)
        {
            var user = _userRepo.Get<UsersView>(id);
            return user;
        }
        /* public async Task <ActionResult<UsersView>> Get(int id)
         {

             var user = _userRepo.Get<users>(id);
             if (user == null)

                 return NotFound();
             return _mapper.Map<UsersView>(user);

         }
          [HttpDelete("{id}")]

          public async Task< ActionResult >Deletet(int id)
           {

               var user1 = _userRepo.Get<users>(id);
               if (user1 == null)

                   return NotFound();
               _userRepo.delete(id);
               return Ok();

           }*/
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userRepo.delete(id);
        }
        [HttpPost]
        public async Task Create([FromBody] UsersView user)
        {
            var UserV = _mapper.Map<users>(user);
            //var user1 = _userRepo.Get<users>(UserV.Id);
             var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst("userID")?.Value;

            UserV.Id = Convert.ToInt32(userId);
            await _userRepo.Add(UserV, UserV.Id);


        }
        [HttpPut]
        public async Task Update(UsersView user)
        {

            var userId = User.Claims?.SingleOrDefault(p => p.Type == "UserId")?.Value;
            await _userRepo.update(_mapper.Map<users>(user), Convert.ToInt32(userId));


            /* var UserV = _mapper.Map<users>(user);
             var claimsIdentity = this.User.Identity as ClaimsIdentity;
             var userId = claimsIdentity.FindFirst("userID")?.Value;

             UserV.Id = Convert.ToInt32(userId);
             await _userRepo.Update(UserV, UserV.Id);*/
        }
        

    }
}
