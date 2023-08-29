using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Core.Data.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork;

namespace Service.Service
{
    public class FileService : IFileService
    {
        #region Field & Constructor
        //private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        //private IAuditLoggerService _auditLoggerService;

        public FileService(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
            //_auditLoggerService = auditLoggerService;
            //_unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        public async Task<string> UploadFileToS3(IFormFile file)
        {
            //var task = "";
            try
            {
                //task = "File Uploading";
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
                       // _auditLoggerService.LogTransactionStatus<LoggerDTO>(user, task, JsonConvert.SerializeObject(itemUrl), "I");
                       //_unitOfWork.Commit();
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
