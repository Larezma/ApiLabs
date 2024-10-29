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
    public class PublicationService : IPublicationService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PublicationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Publication>> GetAll()
        {
            return await _repositoryWrapper.Publication.FindALL();
        }

        public async Task<Publication> GetById(int id)
        {
            var publications = await _repositoryWrapper.Publication
                .FindByCondition(x => x.PublicationsId == id);
            return publications.First();
        }

        public async Task Create(Publication model)
        {
            await _repositoryWrapper.Publication.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Publication model)
        {
            await _repositoryWrapper.Publication.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var publications = await _repositoryWrapper.Publication
                .FindByCondition(x => x.PublicationsId == id);

            await _repositoryWrapper.Publication.Delete(publications.First());
            await _repositoryWrapper.Save();
        }
    }
}
