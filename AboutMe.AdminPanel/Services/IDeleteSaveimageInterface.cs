using Microsoft.AspNetCore.Http;

namespace AboutMe.AdminPanel.Services
{
    public interface IDeleteSaveimageInterface
    {
        string SaveImage(IFormFile formFile);
        bool DeleteImage(string fileName);
    }
}
