﻿using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class UserToAchievementsRepository : RepositoryBase<UserToAchievement>, IUserToAchievementsRepository
    {
        public UserToAchievementsRepository(VitalityMasteryTestContext masteryContext) : base(masteryContext)
        {
        }
    }
}