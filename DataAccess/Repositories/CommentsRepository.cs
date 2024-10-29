using Domain.Interfaces.Repository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class CommentsRepository : RepositoryBase<Comment> , ICommentsRepository
    {
        public CommentsRepository(VitalityMasteryContext masteryContext) : base(masteryContext)
        {
        }
    }
}
