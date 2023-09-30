using CFMServices.Interface;
using CloudFileManager.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.IO.MemoryMappedFiles;

namespace CloudFileManager.Component
{
    public class CardViewComponent : ViewComponent
    {
        private readonly IUserFileService _service;
        public CardViewComponent(IUserFileService service)
        {
            _service = service;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(string mode)
        {
            CardView view= new CardView();
            view.Title = mode;
            if(mode == "Total Files")
            {
                view.Style = "card bg-primary";
                view.Count= await _service.GetUserFileCount("UserFiles");
            }
            else if (mode == "Pending Requests")
            {
                view.Style = "card bg-danger";
                view.Count = await _service.GetUserFileCount("Pending");
            }
            else if (mode == "File Requests")
            {
                view.Style = "card bg-info";
                view.Count = await _service.GetUserFileCount("Requested");
            }
            else if (mode == "Shared Files")
            {
                view.Style = "card bg-success";
                view.Count = await _service.GetUserFileCount("Shared");
            }
            return View(view);
        }
    }
}
