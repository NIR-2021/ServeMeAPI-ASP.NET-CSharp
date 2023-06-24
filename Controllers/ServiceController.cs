using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServeMe_M2.Contract;
using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;
using ServeMe_M2.Model.RequestResponse;

namespace ServeMe_M2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService service;

        public ServiceController(IService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("requestService")]
        public async Task<IActionResult> Post([FromBody] RequestServiceDto requestService)
        {
            Response_temp res = new Response_temp();
            ServiceModel ser = await service.RequestService(requestService);
            if(ser == null)
            {
                res.message = "failure";
                return BadRequest(res);
            }
            else
            {
                res.message = "success";
                res.data = ser;
                return Ok(res);
            }
        }

        [HttpPost]
        [Route("getAllServiceRequeset")]
        public async Task<IActionResult> getAllServicesByUser([FromBody] RequestServiceDto requestServiceDto)
        {
            Response_temp res = new Response_temp();
            var result = await service.getAllServiceRequest(requestServiceDto.Id);

            if(result == null)
            {
                res.message = "failure";
                return Ok(res);
            }
            else
            {
                res.message = "success";
                res.data = result;
                return Ok(res);
            }
        }


        [HttpPost]
        [Route("getCategories")]
        public async Task<IActionResult> getCategories()
        {
            Response_temp res = new Response_temp();
            var data = await service.GetCategories();
            if(data == null)
            {
                res.message = "failure";
                res.data = "";
            }
            else
            {
                res.message = "success";
                res.data = data;

            }

            return Ok(res);
        }


        [HttpPost]
        [Route("getQuotation")]
        public async Task<IActionResult> getQuotation([FromBody] QuotiationRequestTemplate quotationRequestTemplate)
        {
            Response_temp res = new Response_temp();

            var quotation = await service.GetQuotation(quotationRequestTemplate);

            if (quotation == null)
            {
                res.message = "failure";
            }
            else {

                res.message = "success";
                res.data = quotation;
            }
            
            return Ok(res);
        }

        [HttpPost]
        [Route("getPreRequestQuotation")]
        public async Task<IActionResult> getQuotation([FromBody] RequestServiceDto serviceModel)
        {

            

            Response_temp res = new Response_temp();

            var item = service.getPreRequestQuotation(serviceModel);
            if(item == null)
            {
                res.message = "failure";
            }
            else
            {
                res.message = "success";
                res.data = item;
            }

            return Ok(res);


        }

        [HttpPost]
        [Route("acceptService")]
        public async Task<IActionResult> acceptService([FromBody] AcceptService acceptService)
        {
            var accepted = await service.AcceptService(acceptService);
            Response_temp res = new Response_temp();
            if (accepted)
            {
                res.message = "success";
                res.data = acceptService;
            }
            else
            {
                res.message = "failure";
                res.data = "";
            }

            return Ok(res);
        }


        [HttpPost]
        [Route("getPendingServices")]
        public async Task<IActionResult> getPendingServices([FromBody] RequestServiceDto requestServiceDto)
        {
            Response_temp res = new Response_temp();
            var result = await service.getPendingServices(requestServiceDto.Id);

            if (result == null)
            {
                res.message = "failure";
                return Ok(res);
            }
            else
            {
                res.message = "success";
                res.data = result;
                return Ok(res);
            }
        }

        [HttpPost]
        [Route("cancelRequest")]
        public async Task<IActionResult> cancelRequest([FromBody] AcceptService acceptService)
        {
            Response_temp res = new Response_temp();
            var result = await service.cancelRequest(acceptService);
            List<string> data= new List<string>();

            if (result == false)
            {
                res.message = "failure";
                res.data = data;
                return Ok(res);
            }
            else
            {
                res.message = "success";
                res.data = data;
                return Ok(res);
            }
        }


    }
}
