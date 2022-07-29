using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task3_iconnect.repo;
using task3_iconnect.user.model;

namespace task3_iconnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConroller : ControllerBase

    {
        private  IUserInterface _userRepo;

        public UserConroller(IUserInterface userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [ServiceFilter(typeof(Filters))]
        public ActionResult<List<users>> GetAll()
        {
            return Ok (_userRepo.GetAll());


        }
        [HttpGet("{id}")]
        public ActionResult<users> Get(int id)
        {

            var user = _userRepo.Get(id);
            if (user == null)

                return NotFound();
            return user;

        }
        [HttpDelete("{id}")]

        public ActionResult Deletet(int id)
        {

            var user1 = _userRepo.Get(id);
            if (user1 == null)

                return NotFound();
            _userRepo.delete(id);
            return Ok();

        }
        [HttpPost]
        public ActionResult Create([FromBody] users user)
        {
            try
            {
                _userRepo.Add(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
        [HttpPut]
        public ActionResult Update(users user)
        {
          
            _userRepo.Update(user);
            return Ok();


        }

    }
}
