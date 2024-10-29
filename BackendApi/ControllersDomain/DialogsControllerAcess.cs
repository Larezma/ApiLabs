using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogsControllerAcess : Controller
    {
        private IDialogsService _dialogsService;
        public DialogsControllerAcess(IDialogsService dialogsService)
        {
            _dialogsService = dialogsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dialogsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _dialogsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Dialog dialog)
        {
            await _dialogsService.Create(dialog);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Dialog dialog)
        {
            await _dialogsService.Update(dialog);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _dialogsService.Delete(id);
            return Ok();
        }
    }
}
