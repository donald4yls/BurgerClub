using Donald.BurgerClub.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Donald.BurgerClub.IServices
{
    public interface IFileUploadService: IApplicationService
    {
        Task<PhotoToS3Dto> UploadFileToAwsS3Async(IFormFile file);
    }
}
