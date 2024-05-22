using Application.DTO;
using Application2.CQRS.Command;
using Application2.CQRS.Query;
using Application2.DTO;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace Service2.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ApiController
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUsers([FromBody] AddUser addUser)
        {
            return Ok(await Mediator.Send(addUser));
        }

        [HttpGet("GetUsers")]
        public async Task<IEnumerable<UserDTO>> GetUser()
        {
            return await Mediator.Send(new GetUsers());
        }

        [HttpGet("GetUserById")]
        public async Task<IEnumerable<UserDTO>> GetUserById(int id)
        {
            return await Mediator.Send(new GetUserById { Id = id });

        }


        [HttpGet("Communicationdata")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetAsync($"https://localhost:7247/api/Gateway/Product/GetProductByUserId?id={id}");                    
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var product = JsonSerializer.Deserialize<Product[]>(responseBody);
                        return Ok(responseBody);
                    }
                    catch (JsonException ex)
                    {
                        return BadRequest("Error deserializing JSON response: " + ex.Message);
                    }
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet("Communicationdata")]
        //public async Task<IEnumerable<ProductDTO>> GetByUserIdP(int id)
        //{
        //    var product = await Mediator.Send(new GetByUserId { Id = id });
        //    return product;
        //}

        [HttpGet("GetByUserName")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetByUserName(string name)
        {
            if (name == null)
            {
                return BadRequest("Invalid Id");
            }

            var products = await Mediator.Send(new GetByUserName { UserName = name });
            return Ok(products);
        }

    }
}
