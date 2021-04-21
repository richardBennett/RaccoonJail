using System.Threading.Tasks;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

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
    }
}