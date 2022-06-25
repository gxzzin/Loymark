using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetUsers()
        {
            var models = await modelService.GetAll();
            var dtos = mapper.Map<IEnumerable<UserReadDTO>>(models);

            return Ok(dtos);
        }


        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult<UserReadDTO>> GetUserById(int id)
        {
            var userModel = await modelService.Find(id);
            if (userModel != null)
            {
                var userDTO = mapper.Map<UserReadDTO>(userModel);
                return Ok(userDTO);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> CreateUser(UserCreateDTO createUserDTO)
        {
            var userModel = mapper.Map<User>(createUserDTO);
            await modelService.Create(userModel);

            var userReadDTO = mapper.Map<UserReadDTO>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDTO.Id }, userReadDTO);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDTO updateUserDTO)
        {
            var userModel = await modelService.Find(id);
            if (userModel != null)
            {
                mapper.Map<UserUpdateDTO, User>(updateUserDTO, userModel);
                await modelService.Update(userModel);
                return Ok();
            }

            return NotFound();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userModel = await modelService.Find(id);
            if (userModel != null)
            {
                await modelService.Delete(userModel);
                return Ok();
            }

            return NotFound();
        }
    }
}