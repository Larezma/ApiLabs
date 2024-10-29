﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Domain.Interfaces.Wrapper;

namespace Domain.Interfaces.Repository
{
    public interface IMessageUsersRepository : IRepositoryBase<MessageUser>
    {
    }
}
