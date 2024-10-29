using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleControllerAcess : Controller
    {
        private IScheduleService _scheduleService;
        public ScheduleControllerAcess(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _scheduleService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _scheduleService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Schedule schedule)
        {
            await _scheduleService.Create(schedule);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Schedule schedule)
        {
            await _scheduleService.Update(schedule);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _scheduleService.Delete(id);
            return Ok();
        }
    }
}
