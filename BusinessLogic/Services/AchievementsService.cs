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
    public class AchievementsService : IAchievementsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AchievementsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Achievement>> GetAll()
        {
            return await _repositoryWrapper.Achievements.FindALL();
        }

        public async Task<Achievement> GetById(int id)
        {
            var achievements = await _repositoryWrapper.Achievements
                .FindByCondition(x => x.AchievementsId == id);
            return achievements.First();
        }

        public async Task Create(Achievement model)
        {
            await _repositoryWrapper.Achievements.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Achievement model)
        {
            await _repositoryWrapper.Achievements.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var achievements = await _repositoryWrapper.Achievements
                .FindByCondition(x => x.AchievementsId == id);

            await _repositoryWrapper.Achievements.Delete(achievements.First());
            await _repositoryWrapper.Save();
        }
    }
}
