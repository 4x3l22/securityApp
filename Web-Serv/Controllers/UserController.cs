using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Data.Interfaces;
using Web_Serv.Controllers.Interfaces;

namespace Web_Serv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase, IControllerUser
    {
        private readonly IUserBisness _userBusiness;
        public UserController(IUserBisness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _userBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var result = await _userBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Save([FromBody] UserDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Hay error en la entity");
            }

            var result = await _userBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await _userBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userBusiness.Delete(id);
            return NoContent();
        }
    }
}
