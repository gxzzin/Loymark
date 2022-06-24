using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersControl.Data;
using UsersControl.DTO;
using UsersControl.Models;

namespace UsersControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserModelService modelService;
        
        private IMapper mapper;

        public UsersController(IUserModelService modelService, IMapper mapper)
        {
            this.modelService = modelService;
            this.mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetUsers()
        {
            var models = modelService.GetAll().ToList();
            var dtos = mapper.Map<IEnumerable<UserReadDTO>>(models);

            return Ok(dtos);
        }


        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<IEnumerable<UserReadDTO>> GetUserById(int id)
        {
            var userModel = modelService.Find(id);
            if (userModel != null)
            {
                var userDTO = mapper.Map<UserReadDTO>(userModel);
                return Ok(userDTO);   
            }
    
            return NotFound();
        }


        [Route("Create")]
        public ActionResult Create(UserCreateDTO createUserDTO)
        {
            var userModel = mapper.Map<User>(createUserDTO);
            modelService.Create(userModel);
            
            var userReadDTO = mapper.Map<UserReadDTO>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDTO.Id}, userReadDTO);
        }


        [HttpPut("{id}", Name = "Update")]
        public ActionResult Update(int id, UserUpdateDTO updateUserDTO)
        {
            var userModel = modelService.Find(id);
            if (userModel != null)
            {
                mapper.Map<UserUpdateDTO, User>(updateUserDTO, userModel);
                modelService.Update(userModel);
                return Ok();
            }

            return NotFound();
        }


        [HttpDelete("{id}", Name = "Delete")]
        public ActionResult<IEnumerable<UserReadDTO>> Delete(int id)
        {
            var userModel = modelService.Find(id);
            if (userModel != null)
            {
                modelService.Delete(userModel);
                return Ok();   
            }
    
            return NotFound();
        }
    }
}