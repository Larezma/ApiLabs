using Domain.Interfaces.Repository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class TrainingRepository : RepositoryBase<Training> , ITrainingRepository
    {
        public TrainingRepository(VitalityMasteryContext masteryContext) : base(masteryContext)
        {
        }
    }
}
