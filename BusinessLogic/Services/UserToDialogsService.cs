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
    public class UserToDialogsService : IUserToDialogsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserToDialogsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserToDialog>> GetAll()
        {
            return await _repositoryWrapper.UserToDialog.FindALL();
        }

        public async Task<UserToDialog> GetById(int id)
        {
            var userToDialogs = await _repositoryWrapper.UserToDialog
                .FindByCondition(x => x.Id == id);
            return userToDialogs.First();
        }

        public async Task Create(UserToDialog model)
        {
            await _repositoryWrapper.UserToDialog.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(UserToDialog model)
        {
            await _repositoryWrapper.UserToDialog.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var userToDialogs = await _repositoryWrapper.UserToDialog
                .FindByCondition(x => x.Id == id);

            await _repositoryWrapper.UserToDialog.Delete(userToDialogs.First());
            await _repositoryWrapper.Save();
        }
    }
}
