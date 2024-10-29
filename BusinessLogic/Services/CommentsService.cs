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
    public class CommentsService : ICommentsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CommentsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _repositoryWrapper.Comments.FindALL();
        }

        public async Task<Comment> GetById(int id)
        {
            var comments = await _repositoryWrapper.Comments
                .FindByCondition(x => x.CommentsId == id);
            return comments.First();
        }

        public async Task Create(Comment model)
        {
            await _repositoryWrapper.Comments.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Comment model)
        {
            _repositoryWrapper.Comments.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var comments = await _repositoryWrapper.Comments
                .FindByCondition(x => x.CommentsId == id);

            _repositoryWrapper.Comments.Delete(comments.First());
            _repositoryWrapper.Save();
        }
    }
}
