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
    public class ScheduleService : IScheduleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ScheduleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Schedule>> GetAll()
        {
            return await _repositoryWrapper.Schedule.FindALL();
        }

        public async Task<Schedule> GetById(int id)
        {
            var schedule = await _repositoryWrapper.Schedule
                .FindByCondition(x => x.ScheduleId == id);
            return schedule.First();
        }

        public async Task Create(Schedule model)
        {
            await _repositoryWrapper.Schedule.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Schedule model)
        {
            await _repositoryWrapper.Schedule.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var schedule = await _repositoryWrapper.Schedule
                .FindByCondition(x => x.ScheduleId == id);

            await _repositoryWrapper.Schedule.Delete(schedule.First());
            await _repositoryWrapper.Save();
        }
    }
}
