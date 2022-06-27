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
        public async Task<ActionResult<IEnumerable<UserSearchResultDTO>>> GetUsers([FromQuery] UserSearchDTO searchDTO)
        {
            //Get filterd user models...
            var models = await modelService.GetUsers(searchDTO);

            //Map models to dtos...
            var dtos = mapper.Map<IEnumerable<UserReadDTO>>(models);

            //Prepare data...
            var searchResultsDTO = new UserSearchResultDTO(searchDTO.Page, searchDTO.TotalRecords, searchDTO.TotalPages, dtos);

            //Return data...
            return Ok(searchResultsDTO);
        }


        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult<UserReadDTO>> GetUserById(int id)
        {
            var userModel = await modelService.GetUserById(id);
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
            var errorMessage = modelService.ValidateBeforeCreate(userModel);
            if (string.IsNullOrEmpty(errorMessage))
            {
                await modelService.CreateUser(userModel);
                var userReadDTO = mapper.Map<UserReadDTO>(userModel);

                return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDTO.Id }, userReadDTO);
            }

            ModelState.AddModelError("errors", errorMessage);
            return BadRequest(ModelState);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDTO updateUserDTO)
        {
            var userModel = await modelService.GetUserById(id);
            var errorMessage = string.Empty;
            if (userModel != null)
            {
                mapper.Map<UserUpdateDTO, User>(updateUserDTO, userModel);
                errorMessage = modelService.ValidateBeforeUpdate(userModel);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    await modelService.UpdateUser(userModel);
                    return NoContent();
                }

                ModelState.AddModelError("errors", errorMessage);
                return BadRequest(ModelState);
            }

            return NotFound();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userModel = await modelService.GetUserById(id);
            var errorMessage = string.Empty;
            if (userModel != null)
            {
                errorMessage = modelService.ValidateBeforeDelete(userModel);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    await modelService.DeleteUser(userModel);
                    return NoContent();
                }

                ModelState.AddModelError("errors", errorMessage);
                return BadRequest(ModelState);
            }

            return NotFound();
        }
    }
}