using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsControllerAcess : Controller
    {
        private ICommentsService _commentsService;
        public CommentsControllerAcess(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commentsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _commentsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Comment comment)
        {
            await _commentsService.Create(comment);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Comment comment)
        {
            await _commentsService.Update(comment);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentsService.Delete(id);
            return Ok();
        }
    }
}
