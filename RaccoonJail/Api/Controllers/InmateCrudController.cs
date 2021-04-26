﻿using System.Threading.Tasks;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos;
using Models.Requests;

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

        [HttpPost("AddInmate")]
        public async Task<ActionResult<long>> AddInmate(string name, decimal size, ArrestLocation arrestLocation, HungerLevel hungerLevel, HappinessLevel happinessLevel)
        {
            return await _inmateCrudService.AddInmateAndReturnId(name, size, arrestLocation, hungerLevel, happinessLevel);
        }

        [HttpDelete("DeleteInmate/{inmateId:long}")]
        public async Task<ActionResult> DeleteInmate(long inmateId)
        {
            await _inmateCrudService.DeleteInmate(inmateId);
            return Ok();
        }

        [HttpGet("GetInmate/{inmateId:long}")]
        public async Task<ActionResult<InmateDto>> GetInmate(long inmateId)
        {
            return await _inmateCrudService.ReadInmate(inmateId);
        }

        [HttpPatch("UpdateInmate")]
        public async Task<ActionResult> GetInmate([FromBody] InmateUpdateRequest inmateUpdateRequest)
        {
            await _inmateCrudService.UpdateInmate(inmateUpdateRequest);
            return Ok();
        }
    }
}