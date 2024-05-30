using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
           _userDal = userDal;  
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserCreated);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(x=>x.Email==email);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaimDto>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaimDto>>(result);
        }
    }
}
