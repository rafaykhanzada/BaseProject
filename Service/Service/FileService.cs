using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class FileService : IFileService
    {
        #region Field & Constructor

        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public FileService(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }
        #endregion
        #region Methods
        public async Task<string> UploadFileToS3(IFormFile file)
        {
            try
            {
                var timeStamp = DateTime.UtcNow.ToString();
                string fname = file.FileName.ToString().Insert(file.FileName.ToString().IndexOf("."), timeStamp);
                using (var client = new AmazonS3Client(_configuration["AWSAccessKey"], _configuration["AWSSecretKey"], RegionEndpoint.APSoutheast1))
                {
                    using (var newMemoryStream = new MemoryStream())
                    {
                        file.CopyTo(newMemoryStream);

                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            InputStream = newMemoryStream,
                            //Key = file.FileName, file.FileName.ToString().Insert(6,"abc")
                            Key = fname,
                            BucketName = _configuration["BucketName"],
                            CannedACL = S3CannedACL.PublicRead
                        };

                        var fileTransferUtility = new TransferUtility(client);
                        await fileTransferUtility.UploadAsync(uploadRequest);
                        var itemUrl = "https://" + _configuration["BucketName"] + _configuration["AWSUrl"] + fname;
                        return itemUrl;
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        #endregion

    }
}
