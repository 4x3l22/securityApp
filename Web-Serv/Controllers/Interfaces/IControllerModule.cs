using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces
{
    public interface IControllerModule
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<ModuleDto>> GetById(int id);
        Task<ActionResult<ModuleDto>> Save([FromBody] ModuleDto entity);
        Task<IActionResult> Update(int id, [FromBody] ModuleDto entity);
        Task<ActionResult> Delete(int id);
    }
}
