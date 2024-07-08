using Microsoft.AspNetCore.Mvc;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Request.UpdateRequest;
using ShopServer.Business.Service.Interface;
using System;
using System.Threading.Tasks;

namespace ShopServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        public readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> All()
        {
            try
            {
                var all = await _itemService.GetAll();
                if (all == null)
                    return BadRequest("Some Issues in service");
                return Ok(all);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getbyshop/{id}")]
        public async Task<IActionResult> GetByShop(int _id)
        {
            try
            {
                var all = await _itemService.GetByShop(_id);
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
        public async Task<IActionResult> Add([FromBody] ItemAddRequest _request)
        {
            try
            {
                var data = await _itemService.Add(_request);
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
        public async Task<IActionResult> Update([FromBody] ItemUpdateRequest _request)
        {
            try
            {
                var data = await _itemService.Update(_request);
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
                var data = await _itemService.GetItem(_id);
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
                var data = await _itemService.Delete(_id);
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
