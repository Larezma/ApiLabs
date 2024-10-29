using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsControllerAcess : Controller
    {
        private IAchievementsService _achievementsService;
        public AchievementsControllerAcess(IAchievementsService achievementsService)
        {
            _achievementsService = achievementsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _achievementsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _achievementsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Achievement achievement)
        {
            await _achievementsService.Create(achievement);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Achievement achievement)
        {
            await _achievementsService.Update(achievement);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _achievementsService.Delete(id);
            return Ok();
        }
    }
}
