using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServeMe_M2.Contract;
using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;

namespace ServeMe_M2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendor manager;
        private readonly IMapper mapper;

        public VendorController(IVendor manager,IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("registerVendor")]
        public async Task<IActionResult> registerVendor([FromBody] VendorRegDto vendorRegDto)
        {
            int[] categories = vendorRegDto.categoryIds;
            List<VendorDto> list = new List<VendorDto>();
            foreach(int i in categories){
                vendorRegDto.categoryId = i;
                VendorDto temp = mapper.Map<VendorDto>(vendorRegDto);
                list.Add(temp);
                
            }

            Response_temp res = new Response_temp();
            //call manager 

            if (await manager.addVendorWithCat(list))
            {
                res.message = "success";
            }
            else
            {
                res.message = "failure";
            }

            return Ok(res);
        }


        [HttpPost]
        [Route("getVendorDetails")]
        public async Task<IActionResult> getVendorDetails([FromBody] VendorDto vendorDto)
        {
            var vendors = await manager.getVendorDetails(vendorDto);
            Response_temp res = new Response_temp();

            if (vendors != null)
            {
                var vd = new VendorDto();
                string categories = "";
                foreach (var vendor in vendors)
                {
                    categories += vendor.Category.Name;
                    categories += ",";
                    vd = vendor;
                }
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("vendorName", vd.vendorName);
                data.Add("vendorId", vd.vendorId.ToString());
                data.Add("vendorEmail", vd.vendorEmail);
                data.Add("vendorDescription", vd.vendorDescription);
                data.Add("cDate", vd.cDate.ToString());
                data.Add("vendorPhone", vd.vendorPhone);
                data.Add("Id", vd.Id);
                data.Add("categories", categories);

                res.message = "success";
                res.data = data;

            }
            else
            {
                res.message = "failure";
            }

            return Ok(res);
            
        }
 
    }
}
