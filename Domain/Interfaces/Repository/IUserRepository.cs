﻿using System;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Wrapper;

namespace Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
