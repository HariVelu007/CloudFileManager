using CFMDomainModel;
using CFMServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFMServices.Interface
{
    public interface IUserService
    {
        Task<Validation> ValidateUser(string usermailid);
        Task<bool> AddUser(User user, string password);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<ValidationModel<User>> Login(string usermaildid, string password);
        Task<bool> Logout(string usermaildid);

    }
}
