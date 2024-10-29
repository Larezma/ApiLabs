using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersScheduleControllerAcess : Controller
    {
        private ITrainersScheduleService _trainersScheduleService;
        public TrainersScheduleControllerAcess(ITrainersScheduleService trainersScheduleService)
        {
            _trainersScheduleService = trainersScheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _trainersScheduleService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _trainersScheduleService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(TrainersSchedule trainersSchedule)
        {
            await _trainersScheduleService.Create(trainersSchedule);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(TrainersSchedule trainersSchedule)
        {
            await _trainersScheduleService.Update(trainersSchedule);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _trainersScheduleService.Delete(id);
            return Ok();
        }
    }
}
