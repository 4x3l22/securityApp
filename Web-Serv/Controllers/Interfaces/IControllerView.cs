using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces
{
    public interface IControllerView
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<ViewDto>> GetById(int id);
        Task<ActionResult<ViewDto>> Save([FromBody] ViewDto entity);
        Task<IActionResult> Update(int id, [FromBody] ViewDto entity);
        Task<ActionResult> Delete(int id);
    }
}
