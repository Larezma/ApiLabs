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
    public class GroupsService : IGroupsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Group>> GetAll()
        {
            return await _repositoryWrapper.Group.FindALL();
        }

        public async Task<Group> GetById(int id)
        {
            var group = await _repositoryWrapper.Group
                .FindByCondition(x => x.GroupsId == id);
            return group.First();
        }

        public async Task Create(Group model)
        {
            await _repositoryWrapper.Group.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Group model)
        {
            _repositoryWrapper.Group.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var group = await _repositoryWrapper.Group
                .FindByCondition(x => x.GroupsId == id);

            _repositoryWrapper.Group.Delete(group.First());
            _repositoryWrapper.Save();
        }
    }
}
