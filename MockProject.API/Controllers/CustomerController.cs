using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockProject.API.DTO;
using MockProject.API.Reponsitory.Interface;

namespace MockProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "AdminJWT")]
    public class CustomerController : ControllerBase
    {
        #region Init DB
        private ICustomerRepository _repos;
        public CustomerController(ICustomerRepository repos)
        {
            _repos = repos;
        }
        #endregion

        #region Get all customer
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(string? searchString)
        {
            // Get result from repository
            var result = await _repos.GetAll(searchString);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Get 1 customer
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            // Get result from repository
            var result = await _repos.Get(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Add customer
        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerModel model)
        {
            // Get result from repository
            var result = await _repos.Add(model);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Update customer
        [HttpPut]
        public async Task<IActionResult> Update(UpdateInfoModel model)
        {
            // Get result from repository
            var result = await _repos.Update(model);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion

        #region Change status customer
        [HttpPost("changestatus")]
        public async Task<IActionResult> ChangeStatus(string id, bool isActive)
        {
            // Get result from repository
            var result = await _repos.ChangeStatus(id, isActive);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        #endregion
    }
}
