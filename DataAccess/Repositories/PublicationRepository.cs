using Domain.Interfaces.Repository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class PublicationRepository : RepositoryBase<Publication> , IPublicationRepository
    {
        public PublicationRepository(VitalityMasteryContext masteryContext) : base(masteryContext)
        {
        }
    }
}
