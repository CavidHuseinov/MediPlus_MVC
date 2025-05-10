
using MediPlus.Application.ViewModels.FileUpload;

namespace MediPlus.Infrastructure.FileStorage.Interfaces
{
    public interface IAWSUploadService
    {
        Task<FileUploadVM> UploadFileAsync(CreateFileUploadVM fileUploadDto);
    }
}
