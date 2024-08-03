using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces
{
    public interface IControllerUser
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<UserDto>> GetById(int id);
        Task<ActionResult<UserDto>> Save([FromBody] UserDto entity);
        Task<IActionResult> Update(int id, [FromBody] UserDto entity);
        Task<ActionResult> Delete(int id);
    }
}
