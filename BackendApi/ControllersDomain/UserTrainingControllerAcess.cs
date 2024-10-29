using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTrainingControllerAcess : Controller
    {
        private IUserTrainingService _userTrainingService;
        public UserTrainingControllerAcess(IUserTrainingService userTrainingService)
        {
            _userTrainingService = userTrainingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userTrainingService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userTrainingService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserTraining userTraining)
        {
            await _userTrainingService.Create(userTraining);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserTraining userTraining)
        {
            await _userTrainingService.Update(userTraining);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userTrainingService.Delete(id);
            return Ok();
        }
    }
}
