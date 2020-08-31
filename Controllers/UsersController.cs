using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleUser.Data;
using SimpleUser.Models;

namespace SimpleUser.Controllers
{   
    [Route("api/users")]  //api/[controller]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISimpleUserRepo _repository;

        public UsersController (ISimpleUserRepo repository)
        {
            _repository = repository;
        }

        // private readonly MockSimpleUserRepo _repository  = new MockSimpleUserRepo();
        // Get api/users
        [HttpGet]
        public ActionResult <IEnumerable<User>>  GetALlUsers()
        {
            var userItems = _repository.GetUser();

            return Ok(userItems);
        }   

        // Get api/users/{id}
        [HttpGet("{id}")]
        public ActionResult <User> GetUserById(int id)
        {
            var userItems = _repository.GetUserbyId(id);

            return Ok(userItems);
        }
    }
}