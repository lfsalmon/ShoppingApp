using Microsoft.AspNetCore.Mvc;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Service;
using ShopServer.Business.Service.Interface;
using System;
using System.Threading.Tasks;

namespace ShopServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCarController : Controller
    {
        public readonly IShoppingCarService _shoppingCarService;
        public ShoppingCarController(IShoppingCarService shoppingCarService)
        {
            _shoppingCarService = shoppingCarService ?? throw new ArgumentNullException(nameof(shoppingCarService));
        }
        [HttpGet]
        [Route("getbyclient/{id}")]
        public async Task<IActionResult> GetByClient(int _id)
        {
            try
            {
                var data = await _shoppingCarService.GetByClient(_id);
                if (data == null)
                    return BadRequest("Some Issues in service");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("updateshoppingcar")]
        public async Task<IActionResult> Add([FromBody] ShoppingCarAddRequest _request)
        {
            try
            {
                var data = await _shoppingCarService.Add(_request);
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
        public async Task<IActionResult> Delete(ShoppingCarAddRequest _request)
        {
            try
            {
                var data = await _shoppingCarService.Delete(_request);
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
        [Route("deleteall/{id}")]
        public async Task<IActionResult> DeleteAll(int _id)
        {
            try
            {
                var data = await _shoppingCarService.DeleteAll(_id);
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
