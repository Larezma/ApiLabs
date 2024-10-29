using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsControllerAcess : Controller
    {
        private IGroupsService _groupsService;
        public GroupsControllerAcess(IGroupsService groupsService)
        {
            _groupsService = groupsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _groupsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Group group)
        {
            await _groupsService.Create(group);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Group group)
        {
            await _groupsService.Update(group);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupsService.Delete(id);
            return Ok();
        }
    }
}
