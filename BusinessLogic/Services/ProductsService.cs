using System;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Service;
using Domain.Interfaces.Wrapper;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProductsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repositoryWrapper.Products.FindALL();
        }

        public async Task<Product> GetById(int id)
        {
            var products = await _repositoryWrapper.Products
                .FindByCondition(x => x.ProductId == id);
            return products.First();
        }

        public async Task Create(Product model)
        {
            await _repositoryWrapper.Products.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Product model)
        {
            await _repositoryWrapper.Products.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var products = await _repositoryWrapper.Products
                .FindByCondition(x => x.ProductId == id);

            await _repositoryWrapper.Products.Delete(products.First());
            await _repositoryWrapper.Save();
        }
    }
}
