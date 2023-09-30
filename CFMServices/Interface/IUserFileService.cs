using CFMDomainModel;
using CFMServices.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFMServices.Interface
{
    public interface IUserFileService
    {
        Task<int> GetUserFileCount(string mode);
        Task<List<UserFile>> GetUserFiles(int pageno, int pagesize);

        Task<int> GetUserFilesDetailCount();
        Task<List<UserFileView>> GetUserFilesDetail(int pageno, int pagesize);

        Task<List<UserFile>> GetDashBoardData(string mode);

        Task<bool> DeleteUserFile(int id);

        Task<bool> AddUserFile(IFormFile file);

        Task<List<UserFileAccessView>> GetUserFileAccess(int UserFileID);
        Task<bool> AddUserFileAccess(UserFileAccessView view);

        Task<bool> DeleteUserFileAccess(int id);

        Task<bool> VerifyUser(string userMail);
    }
}
