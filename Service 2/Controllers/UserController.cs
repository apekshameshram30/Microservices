using Microsoft.AspNetCore.Mvc;
using Service_2.Entity;

namespace Service_2.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        [Route("GetUsersInfo")]
        [HttpGet]
        public User GetUsersInfo()
        {
            User user = new User();

            user.Id = 100;
            user.Name = "apeksha";
            user.Email = "jitcse.apekshameshram@gmail.com";

            return user;
        }
       
    }
}
