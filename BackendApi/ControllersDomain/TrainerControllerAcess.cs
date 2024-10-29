using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerControllerAcess : Controller
    {
        private ITrainerService _trainerService;
        public TrainerControllerAcess(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _trainerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _trainerService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Trainer trainer)
        {
            await _trainerService.Create(trainer);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Trainer trainer)
        {
            await _trainerService.Update(trainer);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _trainerService.Delete(id);
            return Ok();
        }
    }
}
