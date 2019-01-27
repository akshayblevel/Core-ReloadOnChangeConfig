using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ResponseMessageFromConfig.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ResponseMessage responseMessage;
        public ValuesController(IOptionsSnapshot<ResponseMessage> responseMessage)
        {
            this.responseMessage = responseMessage.Value;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            ApiResponse apiResponse = new ApiResponse();
            apiResponse.Code = (int)Message.Success;
            apiResponse.Message = responseMessage.Values[Message.Success.ToString()];

            return new string[] { apiResponse.Code.ToString(), apiResponse.Message };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
