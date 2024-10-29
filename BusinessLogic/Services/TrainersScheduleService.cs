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
    public class TrainersScheduleService : ITrainersScheduleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TrainersScheduleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<TrainersSchedule>> GetAll()
        {
            return await _repositoryWrapper.TrainersSchedule.FindALL();
        }

        public async Task<TrainersSchedule> GetById(int id)
        {
            var trainersSchedule = await _repositoryWrapper.TrainersSchedule
                .FindByCondition(x => x.Id == id);
            return trainersSchedule.First();
        }

        public async Task Create(TrainersSchedule model)
        {
            await _repositoryWrapper.TrainersSchedule.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(TrainersSchedule model)
        {
            await _repositoryWrapper.TrainersSchedule.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var trainersSchedule = await _repositoryWrapper.TrainersSchedule
                .FindByCondition(x => x.Id == id);

            await _repositoryWrapper.TrainersSchedule.Delete(trainersSchedule.First());
            await _repositoryWrapper.Save();
        }
    }
}
