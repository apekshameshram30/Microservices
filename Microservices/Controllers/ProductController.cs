using Application.CQRS.Command;
using Application.CQRS.Query;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Service1.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ApiController
    {
        [HttpPost("AddProduct")]
        public async Task<IActionResult> ProductAdd([FromBody] AddProduct addProduct)
        {
            return Ok(await Mediator.Send(addProduct));
        }

        [HttpGet("GetAllProduct")]
        public async Task<IEnumerable<ProductDTO>> GetProduct()
        {
            return await Mediator.Send(new GetProduct());
        }


        //Get Product By User Id 

        [HttpGet("GetProductByUserId")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductByUserId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            var products = await Mediator.Send(new GetProductByUserId { Id = id });
            return Ok(products);
        }


        [HttpGet("GetByUserNamebyproduct")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetByUserName(string name)
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
