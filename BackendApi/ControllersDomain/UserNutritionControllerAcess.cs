using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNutritionControllerAcess : Controller
    {
        private IUserNutritionService _userNutritionService;
        public UserNutritionControllerAcess(IUserNutritionService userNutritionService)
        {
            _userNutritionService = userNutritionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userNutritionService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userNutritionService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserNutrition userNutrition)
        {
            await _userNutritionService.Create(userNutrition);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserNutrition userNutrition)
        {
            await _userNutritionService.Update(userNutrition);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userNutritionService.Delete(id);
            return Ok();
        }
    }
}
