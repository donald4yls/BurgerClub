using Amazon;
using Amazon.S3;
using Donald.BurgerClub.IServices;
using Donald.BurgerClub.Settings;
using Donald.BurgerClub.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Donald.BurgerClub.Services
{
    public class FileUploadService: ApplicationService, IFileUploadService
    {
        private readonly AWSConfiguration _awsConfiguration;
        private readonly ILogger<FileUploadService> _logger;

        public FileUploadService(IOptions<AWSConfiguration> options,
            ILogger<FileUploadService> logger)
        {
            _awsConfiguration = options.Value;
            _logger = logger;
        }

        public async Task<PhotoToS3Dto> UploadFileToAwsS3Async(IFormFile file)
        {
            using (var client = new AmazonS3Client(_awsConfiguration.AwsAccessKeyId, 
                _awsConfiguration.AwsSecretAccessKey, RegionEndpoint.GetBySystemName(_awsConfiguration.AwsS3RegionName)))
            {
                var keyName = Guid.NewGuid().ToString();

                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var request = new Amazon.S3.Model.PutObjectRequest
                    {
                        BucketName = _awsConfiguration.AwsS3BucketName,
                        Key = keyName,
                        InputStream = newMemoryStream,
                        CannedACL = S3CannedACL.PublicRead
                    };
                    await client.PutObjectAsync(request);

                    var s3Url = string.Format("http://{0}.s3.amazonaws.com/{1}", _awsConfiguration.AwsS3BucketName, keyName);

                    return new PhotoToS3Dto(file.FileName, s3Url);
                }
            }
        }
    }
}
