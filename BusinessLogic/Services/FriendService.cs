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
    public class FriendService : IFriendService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FriendService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Friend>> GetAll()
        {
            return await _repositoryWrapper.Friend.FindALL();
        }

        public async Task<Friend> GetById(int id)
        {
            var friend = await _repositoryWrapper.Friend
                .FindByCondition(x => x.FriendId == id);
            return friend.First();
        }

        public async Task Create(Friend model)
        {
            await _repositoryWrapper.Friend.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Friend model)
        {
            await _repositoryWrapper.Friend.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var friend = await _repositoryWrapper.Friend
                .FindByCondition(x => x.FriendId == id);

            await _repositoryWrapper.Friend.Delete(friend.First());
            await _repositoryWrapper.Save();
        }
    }
}
