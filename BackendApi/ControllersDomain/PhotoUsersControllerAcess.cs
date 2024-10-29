using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoUsersControllerAcess : Controller
    {
        private IPhotoUsersService _photoUsersService;
        public PhotoUsersControllerAcess(IPhotoUsersService photoUsersService)
        {
            _photoUsersService = photoUsersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _photoUsersService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _photoUsersService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PhotoUser photoUser)
        {
            await _photoUsersService.Create(photoUser);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PhotoUser photoUser)
        {
            await _photoUsersService.Update(photoUser);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _photoUsersService.Delete(id);
            return Ok();
        }
    }
}
