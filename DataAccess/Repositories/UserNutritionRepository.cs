using Domain.Interfaces.Repository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Service;

namespace DataAccess.Repositories
{
    internal class UserNutritionRepository : RepositoryBase<UserNutrition> , IUserNutritionRepository
    {
        public UserNutritionRepository(VitalityMasteryContext masteryContext) : base(masteryContext)
        {
        }
    }
}
