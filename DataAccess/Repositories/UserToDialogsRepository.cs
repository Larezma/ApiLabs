using Domain.Interfaces.Repository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class UserToDialogsRepository : RepositoryBase<UserToDialog> , IUserToDialogRepository
    {
        public UserToDialogsRepository(VitalityMasteryContext masteryContext) : base(masteryContext)
        {
        }
    }
}
