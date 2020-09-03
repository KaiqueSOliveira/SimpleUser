using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name="GetUserById")]
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

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.Id}, userReadDto);
            //return  Ok(userReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int  id, UserUpdateDto userUpdateDto)
        {
            var userMoldelFromRepo = _repository.GetUserbyId(id);

            if (userMoldelFromRepo == null)
            {
                return  NotFound();
            }

            _mapper.Map(userUpdateDto, userMoldelFromRepo);

            _repository.UpdateUser(userMoldelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/users/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateUser(int id , JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var userMoldelFromRepo = _repository.GetUserbyId(id);
            if (userMoldelFromRepo == null)
            {
                return  NotFound();
            }

            var userToPatch =  _mapper.Map<UserUpdateDto>(userMoldelFromRepo);
            patchDoc.ApplyTo(userToPatch, ModelState);
            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, userMoldelFromRepo);

            _repository.UpdateUser(userMoldelFromRepo);

            _repository.SaveChanges();
            
            return NoContent();
        }

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userMoldelFromRepo = _repository.GetUserbyId(id);
            if (userMoldelFromRepo == null)
            {
                return  NotFound();
            }

            _repository.DeleteUser(userMoldelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}