using SalesPytch.Service.Contracts;
using System;
using System.Threading.Tasks;
using SalesPytch.Model;
using SalesPytch.DAL;
using SalesPytch.DAL.Contracts;

namespace SalesPytch.Service.Implementations
{
    public class UserService : IUserService
    {
        IUserDao _userDao = null;

        public UserService(IUserDao userDao )
        {
            _userDao = userDao;
        }       

        public Task<User> ValidateUser(string emailAddress, string password)
        {
            return _userDao.ValidateUser(emailAddress, password);
        }
    }
}
