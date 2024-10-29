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
    public class MessageUsersService : IMessageUsersService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MessageUsersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<MessageUser>> GetAll()
        {
            return await _repositoryWrapper.MessageUsers.FindALL();
        }

        public async Task<MessageUser> GetById(int id)
        {
            var messageUsers = await _repositoryWrapper.MessageUsers
                .FindByCondition(x => x.MessageId == id);
            return messageUsers.First();
        }

        public async Task Create(MessageUser model)
        {
            await _repositoryWrapper.MessageUsers.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(MessageUser model)
        {
            await _repositoryWrapper.MessageUsers.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var messageUsers = await _repositoryWrapper.MessageUsers
                .FindByCondition(x => x.MessageId == id);

            await _repositoryWrapper.MessageUsers.Delete(messageUsers.First());
            await _repositoryWrapper.Save();
        }
    }
}
