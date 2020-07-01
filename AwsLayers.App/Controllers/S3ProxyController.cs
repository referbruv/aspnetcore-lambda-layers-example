using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amazon.S3;
using AwsLayers.Util;

namespace AwsLayers.App.Controllers
{
    /// <summary>
    /// ASP.NET Core controller acting as a S3 Proxy.
    /// </summary>
    [Route("api/[controller]")]
    public class S3ProxyController : ControllerBase
    {
        private readonly IS3Utility utility;

        public S3ProxyController(IS3Utility utility)
        {
            this.utility = utility;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                var response = await this.utility.Get();
                this.Response.ContentType = "text/json";
                return new JsonResult(response);
            }
            catch (AmazonS3Exception e)
            {
                this.Response.StatusCode = (int)e.StatusCode;
                return new JsonResult(e.Message);
            }
        }

        [HttpGet("{key}")]
        public async Task Get(string key)
        {
            try
            {
                var getResponse = await this.utility.Get(key);
                this.Response.ContentType = getResponse.Headers.ContentType;
                getResponse.ResponseStream.CopyTo(this.Response.Body);
            }
            catch (AmazonS3Exception e)
            {
                this.Response.StatusCode = (int)e.StatusCode;
                var writer = new StreamWriter(this.Response.Body);
                writer.Write(e.Message);
            }
        }
    }
}
