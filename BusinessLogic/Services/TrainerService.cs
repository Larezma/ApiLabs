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
    public class TrainerService : ITrainerService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TrainerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Trainer>> GetAll()
        {
            return await _repositoryWrapper.Trainer.FindALL();
        }

        public async Task<Trainer> GetById(int id)
        {
            var trainer = await _repositoryWrapper.Trainer
                .FindByCondition(x => x.TrainerId == id);
            return trainer.First();
        }

        public async Task Create(Trainer model)
        {
            await _repositoryWrapper.Trainer.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Trainer model)
        {
            await _repositoryWrapper.Trainer.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var trainer = await _repositoryWrapper.Trainer
                .FindByCondition(x => x.TrainerId == id);

            await _repositoryWrapper.Trainer.Delete(trainer.First());
            await _repositoryWrapper.Save();
        }
    }
}
