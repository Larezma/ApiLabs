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
    public class UserToRuleService : IUserToRuleService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserToRuleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserToRule>> GetAll()
        {
            return await _repositoryWrapper.UserToRule.FindALL();
        }

        public async Task<UserToRule> GetById(int id)
        {
            var userToRules = await _repositoryWrapper.UserToRule
                .FindByCondition(x => x.Id == id);
            return userToRules.First();
        }

        public async Task Create(UserToRule model)
        {
            await _repositoryWrapper.UserToRule.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(UserToRule model)
        {
            await _repositoryWrapper.UserToRule.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userToRules = await _repositoryWrapper.UserToRule
                .FindByCondition(x => x.Id == id);

            await _repositoryWrapper.UserToRule.Delete(userToRules.First());
            await _repositoryWrapper.Save();
        }
    }
}
