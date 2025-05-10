
using Amazon.S3;
using Amazon.S3.Transfer;
using MediPlus.Application.ViewModels.FileUpload;
using MediPlus.Domain.Settings;
using MediPlus.Infrastructure.FileStorage.Interfaces;
using Microsoft.Extensions.Options;

namespace MediPlus.Infrastructure.FileStorage.Implementations
{
    public class AWSUploadService:IAWSUploadService
    {
        private readonly AmazonS3Client _client;
        private readonly AWS _aws;
        public AWSUploadService(IOptions<AWS> aws)
        {
            _aws = aws.Value;
            var s3Config = new AmazonS3Config
            {
                ServiceURL = aws.Value.EndPointUrl,
                ForcePathStyle = true
            };

            _client = new AmazonS3Client(
                aws.Value.AccessKeyId,
                aws.Value.SecretAccessKey,
                s3Config);
        }


        public async Task<FileUploadVM> UploadFileAsync(CreateFileUploadVM fileUploadDto)
        {
            var fileName = $"{fileUploadDto.FolderName}/{Guid.NewGuid()}_{fileUploadDto.File.FileName}";

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = fileUploadDto.File.OpenReadStream(),
                Key = fileName,
                BucketName = _aws.BucketName
            };

            var transferUtility = new TransferUtility(_client);
            await transferUtility.UploadAsync(uploadRequest);

            var urlFile = $"{_aws.EndPointUrl}/{_aws.BucketName}/{fileName}";

            return new FileUploadVM
            {
                Url = urlFile
            };
        }
    }
}
