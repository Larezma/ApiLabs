using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionControllerAcess : Controller
    {
        private INutritionService _nutritionService;
        public NutritionControllerAcess(INutritionService nutritionService)
        {
            _nutritionService = nutritionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _nutritionService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _nutritionService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Nutrition nutrition)
        {
            await _nutritionService.Create(nutrition);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Nutrition nutrition)
        {
            await _nutritionService.Update(nutrition);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _nutritionService.Delete(id);
            return Ok();
        }
    }
}
