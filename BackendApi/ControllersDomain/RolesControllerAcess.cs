using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;
using System.Data;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesControllerAcess : Controller
    {
        private IRolesService _rolesService;
        public RolesControllerAcess(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rolesService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _rolesService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Role role)
        {
            await _rolesService.Create(role);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Role role)
        {
            await _rolesService.Update(role);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolesService.Delete(id);
            return Ok();
        }
    }
}
