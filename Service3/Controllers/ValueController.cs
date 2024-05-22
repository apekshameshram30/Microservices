using Application3.CQRS.Command;
using Domain.Entity;
using Domain2.Entity;
using Domain3.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Service3.Controllers
{
    public class ValueController : ApiController
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ValueController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("AddCompany")]
        public async Task<IActionResult> CompanyAdd([FromBody] AddCompany addCompany)
        {
            return Ok(await Mediator.Send(addCompany));
        }


        [HttpGet("Product")]
        public async Task<IActionResult> GetProduct(string name)
        {
            if (name == null)
            {
                return BadRequest("Invalid Name");
            }

                var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetAsync($"https://localhost:7247/api/Gateway/Product/GetByUserNamebyproduct?name={name}");

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<Product[]>(responseBody);
                    return Ok(product);
                }
                else
                {
                    return BadRequest("Failed to fetch data");
                }
        }


        [HttpGet("User")]
        public async Task<IActionResult> GetUser(string name)
        {
            if (name == null)
            {
                return BadRequest("Invalid Name");
            }

             var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://localhost:7247/api/Gateway/User/GetByUserName?name={name}");

            if (response.IsSuccessStatusCode)
            {
              var responseBody = await response.Content.ReadAsStringAsync();
              var users = JsonConvert.DeserializeObject<User[]>(responseBody);
              return Ok(users);
            }
           else
           {
            return BadRequest("Failed to fetch data");
           }
        }


        //Get The Details of User And Product by Name in company 
        [HttpGet("CommunicationWith3Services")]
        public async Task<IActionResult> GetByOperationName(string name)
        {
            if (name == null)
            {
                return BadRequest("Invalid Name");
            }
   
                var httpClient = _httpClientFactory.CreateClient();

                var response1 = await httpClient.GetAsync($"https://localhost:7247/api/Gateway/Product/GetByUserNamebyproduct?name={name}");
                var response2 = await httpClient.GetAsync($"https://localhost:7247/api/Gateway/User/GetByUserName?name={name}");

                if (response1.IsSuccessStatusCode && response2.IsSuccessStatusCode)
                {
                    var responseBody1 = await response1.Content.ReadAsStringAsync();
                    var responseBody2 = await response2.Content.ReadAsStringAsync();

                    var products = JsonConvert.DeserializeObject<Product[]>(responseBody1);
                    var users = JsonConvert.DeserializeObject<User[]>(responseBody2);

                    return Ok(new { Product = products, User = users });
                }
                else
                {
                    return BadRequest("Failed to fetch data");
                }
           
        }



    }
}
