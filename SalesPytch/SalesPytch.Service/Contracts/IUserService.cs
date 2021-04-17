using SalesPytch.Model;
using System;
using System.Threading.Tasks;

namespace SalesPytch.Service.Contracts
{
    public interface IUserService
    {
        Task<User> ValidateUser(string emailAddress, string password);
    }
}
