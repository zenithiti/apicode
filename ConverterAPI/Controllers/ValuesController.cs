using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       private readonly IHttpClientFactory _clientFactory;
       
        public IEnumerable<string> Branches { get; private set; }

        public bool GetBranchesError { get; private set; }

        public ValuesController(IHttpClientFactory clientFactory)
        {
           _clientFactory = clientFactory;
        }

        [HttpGet]
        public object Get()
        {

            //string contentRootPath = _hostingEnvironment.ContentRootPath;
            var JSON1 = System.IO.File.ReadAllText( "currencies.json");
            return Ok(JSON1);
        }
        
        [HttpGet("{id}")]
        public async Task<object> GetExchangeRate(int id)
        {
            var client1 = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
          "http://api.openrates.io/latest?base=USD&symbols=GBP");

            var httpResponse = await  client1.SendAsync(request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
          
            return Ok(content);
        }

       
    }
}
