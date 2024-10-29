using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendControllerAcess : Controller
    {
        private IFriendService _friendService;
        public FriendControllerAcess(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _friendService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _friendService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Friend friend)
        {
            await _friendService.Create(friend);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Friend friend)
        {
            await _friendService.Update(friend);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _friendService.Delete(id);
            return Ok();
        }
    }
}
