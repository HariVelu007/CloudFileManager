using Microsoft.AspNetCore.Http;

namespace CFMDomainModel.Helpers
{
    public class FileHelper
    {
        public static string UploadFile(IFormFile file,int ID)
        {
            string URL= Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "UserFiles", ID.ToString()));
            string fileFullName =  "";
            bool basePathExists = Directory.Exists(URL);
            if (!basePathExists)
                Directory.CreateDirectory(URL);
            //var fileName = Path.GetFileNameWithoutExtension(viewModel.PostImg.FileName);
            var filePath = Path.Combine(URL, file.FileName);
            fileFullName = Path.GetFileName(file.FileName);
            if (!File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return filePath;
        }
    }
}
