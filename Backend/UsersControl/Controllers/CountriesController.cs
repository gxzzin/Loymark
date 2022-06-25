using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<IEnumerable<CountryReadDTO>> GetUsers()
        {
            var models = modelService.GetAll().ToList();
            var dtos = mapper.Map<IEnumerable<CountryReadDTO>>(models);

            return Ok(dtos);
        }
    }
}