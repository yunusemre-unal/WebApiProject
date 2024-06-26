﻿using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaimDto> GetClaims(User user);
    }
}
