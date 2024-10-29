using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationControllerAcess : Controller
    {
        private IPublicationService _publicationService;
        public PublicationControllerAcess(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _publicationService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _publicationService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Publication publication)
        {
            await _publicationService.Create(publication);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Publication publication)
        {
            await _publicationService.Update(publication);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _publicationService.Delete(id);
            return Ok();
        }
    }
}
