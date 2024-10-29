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
    public class GroupMembersService : IGroupMembersService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GroupMembersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<GroupMember>> GetAll()
        {
            return await _repositoryWrapper.GroupMembers.FindALL();
        }

        public async Task<GroupMember> GetById(int id)
        {
            var groupMembers = await _repositoryWrapper.GroupMembers
                .FindByCondition(x => x.GroupsId == id);
            return groupMembers.First();
        }

        public async Task Create(GroupMember model)
        {
            await _repositoryWrapper.GroupMembers.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(GroupMember model)
        {
            _repositoryWrapper.GroupMembers.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var groupMembers = await _repositoryWrapper.GroupMembers
                .FindByCondition(x => x.GroupsId == id);

            _repositoryWrapper.GroupMembers.Delete(groupMembers.First());
            _repositoryWrapper.Save();
        }
    }
}
