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
    public class PhotoUsersService : IPhotoUsersService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PhotoUsersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<PhotoUser>> GetAll()
        {
            return await _repositoryWrapper.PhotoUsers.FindALL();
        }

        public async Task<PhotoUser> GetById(int id)
        {
            var photoUsers = await _repositoryWrapper.PhotoUsers
                .FindByCondition(x => x.PhotoId == id);
            return photoUsers.First();
        }

        public async Task Create(PhotoUser model)
        {
            await _repositoryWrapper.PhotoUsers.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(PhotoUser model)
        {
            await _repositoryWrapper.PhotoUsers.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var photoUsers = await _repositoryWrapper.PhotoUsers
                .FindByCondition(x => x.PhotoId == id);

            await _repositoryWrapper.PhotoUsers.Delete(photoUsers.First());
            await _repositoryWrapper.Save();
        }
    }
}
