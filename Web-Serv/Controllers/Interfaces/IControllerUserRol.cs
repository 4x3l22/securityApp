using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces
{
    public interface IControllerUserRol
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<UserRoleDto>> GetById(int id);
        Task<ActionResult<UserRoleDto>> Save([FromBody] UserRoleDto entity);
        Task<IActionResult> Update(int id, [FromBody] UserRoleDto entity);
        Task<ActionResult> Delete(int id);
    }
}
