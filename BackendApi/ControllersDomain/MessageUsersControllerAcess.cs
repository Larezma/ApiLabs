using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageUsersControllerAcess : Controller
    {
        private IMessageUsersService _messageUsersService;
        public MessageUsersControllerAcess(IMessageUsersService messageUsersService)
        {
            _messageUsersService = messageUsersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _messageUsersService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _messageUsersService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(MessageUser messageUser)
        {
            await _messageUsersService.Create(messageUser);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(MessageUser messageUser)
        {
            await _messageUsersService.Update(messageUser);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _messageUsersService.Delete(id);
            return Ok();
        }
    }
}
