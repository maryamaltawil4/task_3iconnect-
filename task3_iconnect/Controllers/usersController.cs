using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task3_iconnect.repo;
using task3_iconnect.user.model;
using task3_iconnect.ViewModels;
using AutoMapper;


namespace task3_iconnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task <ActionResult<UsersView>> Get(int id)
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

        }
        [HttpPost]
        public async Task Create([FromBody] UsersView user)
        {
            var UserV = _mapper.Map<users>(user);
            var user1 = _userRepo.Get<users>(UserV.Id);
            await _userRepo.Add(user1);


        }
        [HttpPut]
        public async Task Update(UsersView user)
        {

            await _userRepo.Update(_mapper.Map<users>(user));


        }

    }
}
