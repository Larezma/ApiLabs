using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserToAchievementsControllerAcess : Controller
    {
        private IUserToAchievementService _userToAchievementService;
        public UserToAchievementsControllerAcess(IUserToAchievementService userToAchievementService)
        {
            _userToAchievementService = userToAchievementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userToAchievementService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userToAchievementService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserToAchievement userToAchievement)
        {
            await _userToAchievementService.Create(userToAchievement);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserToAchievement userToAchievement)
        {
            await _userToAchievementService.Update(userToAchievement);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userToAchievementService.Delete(id);
            return Ok();
        }
    }
}
