using System.Collections.Generic;
using AwsLayers.Util;
using AwsLayers.Util.Models;
using Microsoft.AspNetCore.Mvc;

namespace AwsLayers.App.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesUtility utility;

        public ValuesController(IValuesUtility utility)
        {
            this.utility = utility;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Value> Get()
        {
            return this.utility.Seed();
        }
    }
}
