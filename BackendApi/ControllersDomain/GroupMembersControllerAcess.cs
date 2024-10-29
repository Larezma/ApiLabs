using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMembersControllerAcess : Controller
    {
        private IGroupMembersService _groupMembersService;
        public GroupMembersControllerAcess(IGroupMembersService groupMembersService)
        {
            _groupMembersService = groupMembersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupMembersService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _groupMembersService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(GroupMember groupMember)
        {
            await _groupMembersService.Create(groupMember);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(GroupMember groupMember)
        {
            await _groupMembersService.Update(groupMember);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupMembersService.Delete(id);
            return Ok();
        }
    }
}
