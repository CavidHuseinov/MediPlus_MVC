
using Microsoft.AspNetCore.Http;

namespace MediPlus.Application.ViewModels.FileUpload
{
    public record CreateFileUploadVM
    {
        public IFormFile? File { get; set; }
        public string FolderName { get; set; } = "MediPlus";
    }
}
