using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Domain.Interfaces.Service;

namespace BackendApi.ControllersDomain
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllerAcess : Controller
    {
        private IProductsService _productsService;
        public ProductsControllerAcess(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await _productsService.Create(product);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _productsService.Update(product);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productsService.Delete(id);
            return Ok();
        }
    }
}
