using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyWishingWell.Controllers
{
    [Route("api/")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
