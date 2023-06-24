using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServeMe_M2.Contract;
using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;

namespace ServeMe_M2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuth auth;
        private readonly ILogger<UserController> logger;
        UserModel ck = new UserModel()
        {
            userId = 1,
            name = "nirbheek",
            email = "nirbheek@gmail.com",
            phone = "9924083912",
            address = "Gandhinagar",
            cDate = DateTime.Now,
            isVendor = "True",
            isDeleted = "false"
        };
        UserModel ckk= new UserModel()
        {
            userId = 1,
            name = "nirbheek",
            email = "nirbheek@gmail.com",
            phone = "9924083912",
            address = "Gandhinagar",
            cDate = DateTime.Now,
            isVendor = "True",
            isDeleted = "false"
        };

        public UserController(IAuth auth,ILogger<UserController> logger)
        {//passing interface as paramter means passing an object of the class that implements that interface
            this.auth = auth;
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult check()
        {
            List<UserModel> list = new List<UserModel>();
            list.Add(ck);
            list.Add(ckk);
            return Ok(list);
        }

        [HttpPost]
        [Route("registration1")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] ApiUserDto apiUserDto)
        {
            Response_temp res = new Response_temp();
            var errors = await auth.Register(apiUserDto);
            //logger.LogInformation("At registration:" + errors);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                //logger.LogInformation(ModelState.ToString());
                res.message = "failure";
                res.data = ModelState;
                return BadRequest(res);
            }
            else
            {
                res.message = "Success";
                res.data = null;
                return Ok(res);

            }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            Response_temp rs = new Response_temp();

            var dat = await auth.login(loginDto);
            if (dat["isValid"].ToLower() == "false")
            {
                rs.message = "failure";
                return Unauthorized(rs);
            }
            rs.message = "success";
            rs.data = dat;
            return Ok(rs);
        }


        [HttpPost]
        [Route("getUserDetails")]
        public async Task<IActionResult> GetUserDetails([FromBody] ProfileFetchDto profileFetchDto)
        {
            Response_temp res = new Response_temp();
            var user = await auth.GetUserDetails(profileFetchDto.email,profileFetchDto.Id);
            if(user.Email == null)
            {
                res.message = "failure";
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("errors", "Validation error. Please login again");
                res.data = data;
            }
            else
            {
                res.message = "success";
                res.data = user;
            }
            return Ok(res);
        }
       

    }
}
