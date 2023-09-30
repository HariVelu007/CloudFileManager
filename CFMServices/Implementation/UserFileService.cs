using CFMDomainModel;
using CFMDomainModel.Helpers;
using CFMServices.Config;
using CFMServices.Interface;
using CFMServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CFMServices.Implementation
{
    public class UserFileService : IUserFileService
    {
        private readonly CFMContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public UserFileService(CFMContext context, IHttpContextAccessor httpContext)
        {
            _context= context;
            _httpContext= httpContext;
        }
        private int UserID=> Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        public async Task<int> GetUserFileCount(string mode)
        {         
            //var u= _context.UserFiles.Join(
            //        _context.UserFileAccess,
            //        uf => uf.ID,
            //        ufa => ufa.UserFileID,
            //        (uf, ufa) => new { ufa.UserID, ufa.Status }).Where(x => x.UserID == UserID && x.Status == "Pending").ToQueryString();
            if (mode== "UserFiles")
                return await _context.UserFiles
                    .Where(u => u.UserID == UserID).CountAsync();
            else if(mode=="Pending")                
                return await _context.UserFiles.Join(
                    _context.UserFileAccess,
                    uf => uf.ID,
                    ufa => ufa.UserFileID,
                    (uf, ufa) => new { ufa.UserID, ufa.Status }).Where(x => x.UserID != UserID && x.Status == false).CountAsync();
                   
            else if(mode=="Requested")
                return await _context.UserFiles.Join(
                    _context.UserFileAccess,
                    uf => uf.ID,
                    ufa => ufa.UserFileID,
                    (uf, ufa) => new { ufa.UserID, ufa.Status }).Where(x => x.UserID == UserID && x.Status == false).CountAsync();
            else//Shared
                return await _context.UserFiles.Join(
                    _context.UserFileAccess,
                    uf => uf.ID,
                    ufa => ufa.UserFileID,
                    (uf, ufa) => new { ufa.UserID, ufa.Status }).Where(x => x.UserID == UserID && x.Status == true).CountAsync();
        }
        public async Task<List<UserFile>> GetDashBoardData(string mode)
        {
            if (mode == "Pending")
            {
                return await _context.UserFiles.Join(_context.UserFileAccess,
                        uf => uf.ID,
                        ufa => ufa.UserFileID,
                        (uf, ufa) => new { uf,ufa.UserID, ufa.Status })
                    .Where(x => x.UserID != UserID && x.Status == false).Take(5).OrderBy(o=>o.uf.CreatedDate)
                    .Select(r=>r.uf).ToListAsync();
            }
            else
            {
                return await _context.UserFiles.Join(_context.UserFileAccess,
                        uf => uf.ID,
                        ufa => ufa.UserFileID,
                        (uf, ufa) => new { uf, ufa.UserID, ufa.Status })
                    .Where(x => x.UserID == UserID && x.Status == false).Take(5).OrderBy(o => o.uf.CreatedDate)
                    .Select(r => r.uf).ToListAsync();
            }
        }

        public async Task<bool> AddUserFile(IFormFile file)
        {
            var path= FileHelper.UploadFile(file, UserID);
            UserFile userFile = new UserFile
            {
                UserID = UserID,
                FileName = file.FileName,
                FileExtension = Path.GetExtension(path),
                FileSize= file.Length,
                Visibility= 1,
                CreatedDate = DateTime.Now,
                FilePath = path,
                
            };
            _context.UserFiles.Add(userFile);
            return  await _context.SaveChangesAsync()>0?true:false;
        }

        public async Task<List<UserFile>> GetUserFiles(int pageno, int pagesize)
        {
            var res= _context.UserFiles.Where(u => u.UserID == UserID)
                .Skip((pageno-1)* pagesize).Take(pagesize);
            return await res.ToListAsync();
        }
        public async Task<bool> DeleteUserFile(int id)
        {
            var userfile= await _context.UserFiles.Where(e=>e.ID==id).FirstOrDefaultAsync();
            _context.UserFiles.Remove(userfile);
            return await _context.SaveChangesAsync()>0?true:false;
        }

        public async Task<int> GetUserFilesDetailCount()
        {
            var res = await _context.UserFiles.Where(u => u.UserID == UserID).CountAsync();
            return res;
        }
        public async Task<List<UserFileView>> GetUserFilesDetail(int pageno, int pagesize)
        {
            var res = _context.UserFiles.Where(u => u.UserID == UserID)
                .Include(u=>u.User)       
                .Select(u=> new UserFileView 
                { 
                    ID= u.ID,
                    UserMail= u.User.UserMail,
                    FileName= u.FileName,
                    FileSize= u.FileSize,
                    FileExtension= u.FileExtension,
                    CreatedDate = u.CreatedDate 
                })
                .Skip((pageno - 1) * pagesize).Take(pagesize);
            return await res.ToListAsync();
        }

        public async Task<List<UserFileAccessView>> GetUserFileAccess(int UserFileID)
        {
            if (UserFileID == 0) 
                return new List<UserFileAccessView>();
            var res= _context.UserFileAccess.Where(uf=> uf.UserFileID== UserFileID)
                .Join(
                    _context.Users,
                    uf=>uf.UserID,
                    u=>u.ID,
                    (u,uf)=>new UserFileAccessView() {ID=u.ID, UserID= uf.ID,UsermailID=uf.UserMail ,UserFileID=u.UserFileID } 
                    ).OrderBy(uf=>uf.UserID).Take(5);
            return await res.ToListAsync();
        }

        public async Task<bool> AddUserFileAccess(UserFileAccessView view)
        {
            UserFileAccess userFileAccess = new UserFileAccess
            {
                UserID = view.UserID,
                Status = true,
                UserFileID = view.UserFileID
            };
            _context.UserFileAccess.Add(userFileAccess);
            return await _context.SaveChangesAsync()>0?true:false;
        }
        public async Task<bool> DeleteUserFileAccess(int id )
        {            
            var res = _context.UserFileAccess.Where(u => u.ID.Equals(id)).FirstOrDefault();
            _context.UserFileAccess.Remove(res);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> VerifyUser(string userMail)
        {
            int cnt=await _context.Users.Where(u=> u.UserMail==userMail).CountAsync();
            return cnt > 0;
        }
    }
}
