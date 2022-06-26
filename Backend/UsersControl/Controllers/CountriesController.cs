using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersControl.Data;
using UsersControl.DTO;

namespace UsersControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryModelService modelService;
        private IMapper mapper;

        public CountriesController(ICountryModelService modelService, IMapper mapper)
        {
            this.modelService = modelService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryReadDTO>>> GetUsers()
        {
            var models = await modelService.GetCountries();
            var dtos = mapper.Map<IEnumerable<CountryReadDTO>>(models);

            return Ok(dtos);
        }
    }
}