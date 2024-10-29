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
    public class UserTrainingService : IUserTrainingService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserTrainingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserTraining>> GetAll()
        {
            return await _repositoryWrapper.UserTraining.FindALL();
        }

        public async Task<UserTraining> GetById(int id)
        {
            var userTraining = await _repositoryWrapper.UserTraining
                .FindByCondition(x => x.Id == id);
            return userTraining.First();
        }

        public async Task Create(UserTraining model)
        {
            await _repositoryWrapper.UserTraining.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(UserTraining model)
        {
            _repositoryWrapper.UserTraining.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userTraining = await _repositoryWrapper.UserTraining
                .FindByCondition(x => x.Id == id);

            _repositoryWrapper.UserTraining.Delete(userTraining.First());
            _repositoryWrapper.Save();
        }
    }
}
