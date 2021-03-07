using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrate;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,ReCapProjectContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.ID equals userOperationClaim.OperationClaimID
                             where userOperationClaim.UserID == user.ID
                             select new OperationClaim { ID = operationClaim.ID, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
