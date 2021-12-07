﻿using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.Upload;
using MKTFY.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MKTFY.Repositories.Repositories.Interfaces;

namespace MKTFY.Services.Services.Interfaces
{
    public class UploadService : IUploadService
    {

        private readonly IConfiguration _config;
        private readonly IUploadRepository _uploadRepository;

        public UploadService(IConfiguration config, IUploadRepository uploadRepository)
        {
            _config = config;
            _uploadRepository = uploadRepository;
        }

        public async Task<List<UploadResultVM>> UploadFiles(List<IFormFile> files)
        {

            var results = new List<UploadResultVM>();

            // Iterate over all the files
            foreach (var file in files)
            {
                var newId = Guid.NewGuid();
                var bucket = _config.GetSection("AWS").GetValue<string>("ImageBucket");
                var region = _config.GetSection("AWS").GetValue<string>("Region");

                // Preform the upload
                using (var memoryStream = new MemoryStream())
                {

                    await file.CopyToAsync(memoryStream);

                    // Upload the file
                    var s3Client = new AmazonS3Client(Amazon.RegionEndpoint.GetBySystemName(region));
                    var fileTransfer = new TransferUtility(s3Client);
                    await fileTransfer.UploadAsync(memoryStream, bucket, newId.ToString());
                }

                // Store the file info for reference by other entities
                await _uploadRepository.Create(new Upload
                {
                    Id = newId,
                    Url = $"https://{bucket}.s3.{region}.amazonaws.com/{newId}"
                });

                // Build the response object
                results.Add(new UploadResultVM
                {
                    Id = newId
                });


            }

            return results;
        }

    }
}
