using System.Threading.Tasks;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class InmateCrudController : ControllerBase
    {
        private readonly IInmateCrudService _inmateCrudService;

        public InmateCrudController(IInmateCrudService inmateCrudService)
        {
            _inmateCrudService = inmateCrudService;
        }

        [HttpGet("GetInmate/{inmateId}")]
        public async Task<ActionResult<InmateDto>> GetInmate(long inmateId)
        {
            return await _inmateCrudService.ReadInmate(inmateId);
        }

        [HttpPost("AddInmate")]
        public async Task<ActionResult<long>> AddInmate(string name, decimal size, ArrestLocation arrestLocation, HungerLevel hungerLevel, HappinessLevel happinessLevel)
        {
            return await _inmateCrudService.AddInmateAndReturnId(name, size, arrestLocation, hungerLevel, happinessLevel);
        }
    }
}