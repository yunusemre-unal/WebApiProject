using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaimDto>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
    }
}
