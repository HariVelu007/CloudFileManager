using CFMServices.Interface;
using CloudFileManager.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CloudFileManager.Component
{
    public class DGridViewComponent: ViewComponent
    {
        private readonly IUserFileService _service;       
        public DGridViewComponent(IUserFileService service )
        {
            _service = service;
          
        }
        public async Task<IViewComponentResult> InvokeAsync(string mode)
        {           
            var res = await _service.GetDashBoardData(mode);
            return View(res);            
            
        }
    }
}
