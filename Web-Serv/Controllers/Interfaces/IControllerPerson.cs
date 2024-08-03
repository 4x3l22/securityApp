using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web_Serv.Controllers.Interfaces
{
    public interface IControllerPerson
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<PersonDto>> GetById(int id);
        Task<ActionResult<PersonDto>> Save([FromBody] PersonDto entity);
        Task<IActionResult> Update(int id, [FromBody] PersonDto entity);
        Task<ActionResult> Delete(int id);
    }
}
