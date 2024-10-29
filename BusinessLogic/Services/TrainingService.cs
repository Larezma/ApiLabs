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
    public class TrainingService : ITrainingService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TrainingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Training>> GetAll()
        {
            return await _repositoryWrapper.Training.FindALL();
        }

        public async Task<Training> GetById(int id)
        {
            var training = await _repositoryWrapper.Training
                .FindByCondition(x => x.Id == id);
            return training.First();
        }

        public async Task Create(Training model)
        {
            await _repositoryWrapper.Training.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Training model)
        {
            _repositoryWrapper.Training.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var training = await _repositoryWrapper.Training
                .FindByCondition(x => x.Id == id);

            _repositoryWrapper.Training.Delete(training.First());
            _repositoryWrapper.Save();
        }
    }
}
