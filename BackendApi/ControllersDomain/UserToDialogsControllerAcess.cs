using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserToDialogsControllerAcess : Controller
    {
        private IUserToDialogsService _userToDialogsService;
        public UserToDialogsControllerAcess(IUserToDialogsService userToDialogsService)
        {
            _userToDialogsService = userToDialogsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userToDialogsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userToDialogsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserToDialog userToDialog)
        {
            await _userToDialogsService.Create(userToDialog);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserToDialog userToDialog)
        {
            await _userToDialogsService.Update(userToDialog);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userToDialogsService.Delete(id);
            return Ok();
        }
    }
}
