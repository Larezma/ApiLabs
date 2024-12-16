using Domain.Interfaces.Service;
using Domain.Interfaces.Wrapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class RolesService : IRolesService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RolesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _repositoryWrapper.Roles.FindALL();
        }

        public async Task<Role> GetById(int id)
        {
            var roles = await _repositoryWrapper.Roles
                .FindByCondition(x => x.Id == id);
            return roles.First();
        }

        public async Task Create(Role model)
        {
            await _repositoryWrapper.Roles.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Role model)
        {
            await _repositoryWrapper.Roles.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var roles = await _repositoryWrapper.Roles
                .FindByCondition(x => x.Id == id);

            await _repositoryWrapper.Roles.Delete(roles.First());
            await _repositoryWrapper.Save();
        }
    }
}