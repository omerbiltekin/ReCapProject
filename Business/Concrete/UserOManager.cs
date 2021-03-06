using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOManager : IUserOService
    {
        IUserODal _userODal;
        public UserOManager(IUserODal userODal)
        {
            _userODal = userODal;
        }
        public void Add(User user)
        {
            _userODal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userODal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userODal.GetClaims(user);
        }
    }
}
