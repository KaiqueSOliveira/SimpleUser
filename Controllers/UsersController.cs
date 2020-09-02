using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleUser.Data;
using SimpleUser.Dtos;
using SimpleUser.Models;

namespace SimpleUser.Controllers
{   
    [Route("api/users")]  //api/[controller]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISimpleUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController (ISimpleUserRepo repository, IMapper mapper)
        {
            _repository = repository;  
            _mapper = mapper;
        }

        // private readonly MockSimpleUserRepo _repository  = new MockSimpleUserRepo();
        // Get api/users
        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>>  GetALlUsers()
        {
            var userItems = _repository.GetAllUser();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }   

        // Get api/users/{id}
        [HttpGet("{id}")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var userItems = _repository.GetUserbyId(id);

            if (userItems != null){
                 return Ok(_mapper.Map<UserReadDto>(userItems));
            }
                 return NotFound();
        }

        // POST api/users
        [HttpPost]
        public ActionResult <UserCreateDto> CreateUser(UserCreateDto createUser)
        {
            var userModel = _mapper.Map<User>(createUser);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            return Ok(userModel);
        }

    }
}