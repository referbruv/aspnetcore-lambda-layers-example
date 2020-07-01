using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwsLayers.Util
{
    public interface IS3Utility
    {
        Task<List<S3Object>> Get();
        Task<GetObjectResponse> Get(string key);
    }

    public class S3Utility : IS3Utility
    {
        public const string AppS3BucketKey = "my-testapi-s3-bucket";

        IAmazonS3 S3Client { get; set; }
        string BucketName { get; set; }

        public S3Utility(IConfiguration configuration, ILogger<S3Utility> logger, IAmazonS3 s3Client)
        {
            this.S3Client = s3Client;

            this.BucketName = configuration[AppS3BucketKey];
            if (string.IsNullOrEmpty(this.BucketName))
            {
                logger.LogCritical("Missing configuration for S3 bucket. The AppS3Bucket configuration must be set to a S3 bucket.");
                throw new Exception("Missing configuration for S3 bucket. The AppS3Bucket configuration must be set to a S3 bucket.");
            }

            logger.LogInformation($"Configured to use bucket {this.BucketName}");
        }

        public async Task<List<S3Object>> Get()
        {
            var listResponse = await this.S3Client.ListObjectsV2Async(new ListObjectsV2Request
            {
                BucketName = this.BucketName
            });

            try
            {
                return listResponse.S3Objects;
            }
            catch (AmazonS3Exception)
            {
                throw;
            }
        }

        public async Task<GetObjectResponse> Get(string key)
        {
            try
            {
                var getResponse = await this.S3Client.GetObjectAsync(new GetObjectRequest
                {
                    BucketName = this.BucketName,
                    Key = key
                });

                return getResponse;
            }
            catch (AmazonS3Exception)
            {
                throw;
            }
        }
    }
}
