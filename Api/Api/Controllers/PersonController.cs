using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDto personDto)
        {
            var result = _personService.Create(personDto);
            if (result.IsCompletedSuccessfully) //IsSuccess
                return Ok(result);

            return BadRequest(result);
        }
    }
}
