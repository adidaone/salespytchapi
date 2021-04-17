
using SalesPytch.Model;
using System.Threading.Tasks;

namespace SalesPytch.DAL.Contracts
{
    public interface IUserDao
    {
        Task<User> ValidateUser(string emailAddress, string password);
    }
}
