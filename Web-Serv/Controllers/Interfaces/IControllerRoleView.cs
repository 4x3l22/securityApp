using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces
{
    public interface IControllerRoleView
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<Role_viewDto>> GetById(int id);
        Task<ActionResult<Role_viewDto>> Save([FromBody] Role_viewDto entity);
        Task<IActionResult> Update(int id, [FromBody] Role_viewDto entity);
        Task<ActionResult> Delete(int id);
    }
}
