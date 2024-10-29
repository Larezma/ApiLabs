using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingControllerAcess : Controller
    {
        private ITrainingService _trainingService;
        public TrainingControllerAcess(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _trainingService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _trainingService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Training training)
        {
            await _trainingService.Create(training);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Training training)
        {
            await _trainingService.Update(training);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _trainingService.Delete(id);
            return Ok();
        }
    }
}
