﻿using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IRepository;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole, int>, IUserRoleRepository
    {

        public UserRoleRepository(ApplicationDbContext dbContext, ILogHelper logger) : base(dbContext, logger)
        {

        }

    }
}