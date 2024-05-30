using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfGenericRepositoryBase<NortwindDbContext, User>, IUserDal
    {
        public List<OperationClaimDto> GetClaims(User user)
        {
            NortwindDbContext context = new();
            var result = from oc in context.OperationClaims
                         join uoc in context.UserOperationClaims on oc.Id equals uoc.OperationClaimId
                         where uoc.UserId == user.Id
                         select
                        new OperationClaimDto
                        {
                            Id = oc.Id,
                            Name = oc.Name
                        };
            return result.ToList();

        }
    }
}
