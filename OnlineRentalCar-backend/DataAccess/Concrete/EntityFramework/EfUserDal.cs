using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Castle.Core.Internal;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

    public List<OperationClaim> SetClaims()
    {
      using (var context = new RentACarContext())
      {
        var result = from operationClaim in context.OperationClaims
                     select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

        return result.ToList();
      }
    }



    public bool AssignClaimsToUser(User user, List<OperationClaim> operationClaims)
    {
      if (operationClaims.IsNullOrEmpty())
      {
        return false;
      }

      Trace.WriteLine(operationClaims.Count);
      using (var context = new RentACarContext())
      {
        foreach (var operationClaim in operationClaims)
        {
          var userOperationClaim = new UserOperationClaim
          {
            UserId = user.Id,
            OperationClaimId = operationClaim.Id
          };

          context.UserOperationClaims.Add(userOperationClaim);
        }

        context.SaveChanges();
        return true;
      }
    }


    public List<UserDto> GetUsersDtos(Expression<Func<UserDto, bool>> filter = null)
        {
            using (var context = new RentACarContext())
            {
                var result = from user in context.Users
                             select new UserDto
                             {
                                 Id = user.Id,
                                 Email = user.Email,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }


  }
}
