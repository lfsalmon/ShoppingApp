using Microsoft.AspNetCore.Authorization;
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
    public class ShopController :Controller
    {
        public readonly IStoreService _shopsService;

        public ShopController(IStoreService shopsService)
        {
            _shopsService = shopsService ?? throw new ArgumentNullException(nameof(shopsService));
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> All()
        {
            try
            {
                var all = await _shopsService.GetAll();
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
        public async Task<IActionResult> Add([FromBody] StoreAddRequest _request)
        {
            try
            {
                var data = await _shopsService.Add(_request);
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
        public async Task<IActionResult> Update([FromBody] StoreUpdateRequest _request)
        {
            try
            {
                var data = await _shopsService.Update(_request);
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
                var data = await _shopsService.GetShop(_id);
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
                var data = await _shopsService.Delete(_id);
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
