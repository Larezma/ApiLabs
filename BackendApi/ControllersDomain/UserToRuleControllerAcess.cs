using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserToRuleControllerAcess : Controller
    {
        private IUserToRuleService _userToRuleService;
        public UserToRuleControllerAcess(IUserToRuleService userToRuleService)
        {
            _userToRuleService = userToRuleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userToRuleService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userToRuleService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserToRule userToRule)
        {
            await _userToRuleService.Create(userToRule);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserToRule userToRule)
        {
            await _userToRuleService.Update(userToRule);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userToRuleService.Delete(id);
            return Ok();
        }
    }
}
