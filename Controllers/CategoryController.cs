using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServeMe_M2.Contract;
using ServeMe_M2.Model;
using ServeMe_M2.Repo;

namespace ServeMe_M2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory category;

        public CategoryController(ICategory category)
        {
            this.category = category;
        }

        [HttpPost]
        [Route("getCategory")]
        public async Task<IActionResult> getCategory([FromBody] Category categ)
        {
            Response_temp res = new Response_temp();
            Category cat = await category.GetCategory(categ.Name);
            if(cat == null)
            {
                res.message = "failure";
            }
            else
            {
                res.message = "success";
                res.data = cat;}

            return Ok(res);
        }

    }
}
