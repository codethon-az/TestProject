using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrchestratorController : ControllerBase
    {
        public const string OrchestratorServices = "https://az-snappers-orchestrator.azurewebsites.net/api/property";

        // GET api/values
        [HttpGet]
        public string Get()
        {


            using (var httpClient = new HttpClient())
            {

                using (var res = httpClient.GetAsync(OrchestratorServices))
                {
                    var apiResponse = res.Result.Content.ReadAsStringAsync().Result;
                    if (res.Result.IsSuccessStatusCode)
                    {
                        return "Service is healthy";
                    }
                    else return "Problem with service";
                }
            }

            
        }
    }


}

