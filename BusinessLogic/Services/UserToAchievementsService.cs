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
    public class UserToAchievementsService : IUserToAchievementService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserToAchievementsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserToAchievement>> GetAll()
        {
            return await _repositoryWrapper.UserToAchievements.FindALL();
        }

        public async Task<UserToAchievement> GetById(int id)
        {
            var userToAchievements = await _repositoryWrapper.UserToAchievements
                .FindByCondition(x => x.Id == id);
            return userToAchievements.First();
        }

        public async Task Create(UserToAchievement model)
        {
            await _repositoryWrapper.UserToAchievements.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(UserToAchievement model)
        {
            _repositoryWrapper.UserToAchievements.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userToAchievements = await _repositoryWrapper.UserToAchievements
                .FindByCondition(x => x.Id == id);

            _repositoryWrapper.UserToAchievements.Delete(userToAchievements.First());
            _repositoryWrapper.Save();
        }
    }
}
