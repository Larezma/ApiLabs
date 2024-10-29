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
    public class UserNutritionService : IUserNutritionService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserNutritionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserNutrition>> GetAll()
        {
            return await _repositoryWrapper.UserNutrition.FindALL();
        }

        public async Task<UserNutrition> GetById(int id)
        {
            var userNutritions = await _repositoryWrapper.UserNutrition
                .FindByCondition(x => x.UserNutritionId == id);
            return userNutritions.First();
        }

        public async Task Create(UserNutrition model)
        {
            await _repositoryWrapper.UserNutrition.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(UserNutrition model)
        {
            _repositoryWrapper.UserNutrition.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userNutritions = await _repositoryWrapper.UserNutrition
                .FindByCondition(x => x.UserNutritionId == id);

            _repositoryWrapper.UserNutrition.Delete(userNutritions.First());
            _repositoryWrapper.Save();
        }
    }
}
