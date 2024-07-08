using Microsoft.AspNetCore.Mvc;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Request.UpdateRequest;
using ShopServer.Business.Service;
using ShopServer.Business.Service.Interface;
using System.Threading.Tasks;
using System;

namespace ShopServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        public readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> All()
        {
            try
            {
                var all = await _customerService.GetAll();
                if (all == null)
                    return BadRequest("Some Issues in service");
                return Ok(all);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] CustomerAddRequest _request)
        {
            try
            {
                var data = await _customerService.Add(_request);
                if (data == null)
                    return BadRequest("Some Issues in service");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] CustomerUpdateRequest _request)
        {
            try
            {
                var data = await _customerService.Update(_request);
                if (data == null)
                    return BadRequest("Some Issues in service");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetById(int _id)
        {
            try
            {
                var data = await _customerService.GetCustomer(_id);
                if (data == null)
                    return BadRequest("Some Issues in service");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int _id)
        {
            try
            {
                var data = await _customerService.Delete(_id);
                if (data == null)
                    return BadRequest("Some Issues in service");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
