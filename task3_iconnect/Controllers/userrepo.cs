using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task3_iconnect.repo;
using task3_iconnect.user.model;

namespace task3_iconnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userrepo : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<users>> GetAll()
        {
            return users_.Getall();
        }

        [HttpGet("{id}")]
        public ActionResult<users> Get(int id)
        {
            var users = users_.Get(id);
            if (users == null)
                return NotFound();
            return users;

        }
        [HttpDelete]
        public ActionResult delete(int id)
        {
            var users = users_.Get(id);
            if (users == null)
                return NotFound();
            users_.delete(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult create(users users )
        {
            users_.add(users);
            return Ok();
        }
        [HttpPut]
        public ActionResult update(int id,users users)
        {
        
            var users2 = users_.Get(id);
            if (users == null | users2 ==null |users.id != id) 
                return NotFound();
            users_.update(users);
            return Ok();
        }
    }

}
