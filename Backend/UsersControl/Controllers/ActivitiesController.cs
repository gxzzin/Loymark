using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersControl.Data;
using UsersControl.DTO;

namespace UsersControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityModelService modelService;
        private IMapper mapper;

        public ActivitiesController(IActivityModelService modelService, IMapper mapper)
        {
            this.modelService = modelService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivitySearchResultDTO>>> GetActivities([FromQuery] ActivitySearchDTO searchDTO)
        {
            //Get filterd user models...
            var models = await modelService.GetActivities(searchDTO);

            //Map models to dtos...
            var dtos = mapper.Map<IEnumerable<ActivityReadDTO>>(models);

            //Prepare data...
            var searchResultsDTO = new ActivitySearchResultDTO(searchDTO.Page, searchDTO.TotalRecords, searchDTO.TotalPages, dtos);

            //Return data...
            return Ok(searchResultsDTO);
        }
    }
}