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
    public class NutritionService : INutritionService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public NutritionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Nutrition>> GetAll()
        {
            return await _repositoryWrapper.Nutrition.FindALL();
        }

        public async Task<Nutrition> GetById(int id)
        {
            var nutrition = await _repositoryWrapper.Nutrition
                .FindByCondition(x => x.NutritionId == id);
            return nutrition.First();
        }

        public async Task Create(Nutrition model)
        {
            await _repositoryWrapper.Nutrition.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Nutrition model)
        {
            await _repositoryWrapper.Nutrition.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var nutrition = await _repositoryWrapper.Nutrition
                .FindByCondition(x => x.NutritionId == id);

            await _repositoryWrapper.Nutrition.Delete(nutrition.First());
            await _repositoryWrapper.Save();
        }
    }
}
