using CFMDomainModel;
using CFMServices.Interface;
using CFMServices.Model;
using CloudFileManager.Helpers;
using CloudFileManager.Helpers.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;
using UI_COMMON_HELPER.Helper;

namespace CloudFileManager.Controllers
{
    public class MyFilesController : Controller
    {
        private readonly IUserFileService _userFileService;
        public MyFilesController(IUserFileService userFileService)
        {
            _userFileService = userFileService;
        }
        public async Task<ActionResult<ListResponse<UserFileView>>> Index(int pageno=1, int pagesize = 10)
        {
            ListResponse<UserFileView> response = new ListResponse<UserFileView>();

            response.TotalRecords = await _userFileService.GetUserFilesDetailCount();
            response.Model = await _userFileService.GetUserFilesDetail(pageno, pagesize);
            response.PageSize = pagesize;
            response.PageNo = pageno;
            
            return View(response);
        }
        [HttpPost]
        public async Task<ActionResult> AddFile(IFormFile iUpload)
        {
            if(iUpload== null)
            {
                TempData["Status"] = HTMLHelper.Alert("danger", "No File to upload");
                return RedirectToAction("Index");
            }
            var status = await _userFileService.AddUserFile(iUpload);
            TempData["Status"] = status ? HTMLHelper.Alert("success", "File uploaded deleted") : HTMLHelper.Alert("danger", "File upload failed");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> EditFile(int ID)
        {
            var res = await _userFileService.GetUserFileAccess(ID);
            return PartialView("_UserFileAccess", res);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteFile(int id)//test
        {
            var status= await _userFileService.DeleteUserFile(id);
            TempData["Status"] = status ? HTMLHelper.Alert("success", "File sucessfully deleted") : HTMLHelper.Alert("danger", "File delete failed");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult OpenAddWindow()
        {                     
            return PartialView("_AddUserFile");
        }
        [HttpGet]
        public async Task<bool> VerifyUser(string usermail)
        {
            bool res= await _userFileService.VerifyUser(usermail);
            return res;
        }
    

        [HttpPost]
        public async Task<ActionResult> AddUserAccess(UserFileAccessView viewModel)
        {
            if (viewModel == null)
                return null;
            var res = await _userFileService.AddUserFileAccess(viewModel);
            return RedirectToAction("EditUserAccess");
        }
        [HttpGet]
        public async Task<ActionResult> DeleteUserAccess(int id)
        {
            var res = await _userFileService.DeleteUserFileAccess(id);
            return RedirectToAction("EditUserAccess");
        }
    }
}
