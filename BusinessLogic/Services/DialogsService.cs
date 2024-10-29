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
    public class DialogsService : IDialogsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public DialogsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Dialog>> GetAll()
        {
            return await _repositoryWrapper.Dialogs.FindALL();
        }

        public async Task<Dialog> GetById(int id)
        {
            var dialogs = await _repositoryWrapper.Dialogs
                .FindByCondition(x => x.DialogsId == id);
            return dialogs.First();
        }

        public async Task Create(Dialog model)
        {
            await _repositoryWrapper.Dialogs.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Dialog model)
        {
            await _repositoryWrapper.Dialogs.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var dialogs = await _repositoryWrapper.Dialogs
                .FindByCondition(x => x.DialogsId == id);

            await _repositoryWrapper.Dialogs.Delete(dialogs.First());
            await _repositoryWrapper.Save();
        }
    }
}
