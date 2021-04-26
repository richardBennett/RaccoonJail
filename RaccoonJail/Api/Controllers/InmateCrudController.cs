using System.Threading.Tasks;
using Database.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Dtos;
using Models.Requests;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class InmateCrudController : ControllerBase
    {
        private readonly IInmateCrudService _inmateCrudService;
        private readonly ILogger<InmateCrudController> _logger;

        public InmateCrudController(IInmateCrudService inmateCrudService, ILogger<InmateCrudController> logger)
        {
            _inmateCrudService = inmateCrudService;
            _logger = logger;
        }

        [HttpPost("AddInmate")]
        public async Task<ActionResult<long>> AddInmate(string name, decimal size, ArrestLocation arrestLocation, HungerLevel hungerLevel, HappinessLevel happinessLevel)
        {
            _logger.LogInformation("I just got an AddInmate request");
            return await _inmateCrudService.AddInmateAndReturnId(name, size, arrestLocation, hungerLevel, happinessLevel);
        }

        [HttpDelete("DeleteInmate/{inmateId:long}")]
        public async Task<ActionResult> DeleteInmate(long inmateId)
        {
            _logger.LogInformation("I just got a DeleteInmate request for {id}", inmateId);
            await _inmateCrudService.DeleteInmate(inmateId);
            return Ok();
        }

        [HttpGet("GetInmate/{inmateId:long}")]
        public async Task<ActionResult<InmateDto>> GetInmate(long inmateId)
        {
            _logger.LogInformation($"I just got a GetInmate request for {inmateId}");
            return await _inmateCrudService.ReadInmate(inmateId);
        }

        [HttpPatch("UpdateInmate")]
        public async Task<ActionResult> GetInmate([FromBody] InmateUpdateRequest inmateUpdateRequest)
        {
            _logger.LogInformation("I just got a GetInmate request for {inmateId}", inmateUpdateRequest.Id);
            await _inmateCrudService.UpdateInmate(inmateUpdateRequest);
            return Ok();
        }
    }
}