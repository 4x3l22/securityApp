using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interfaces.Security
{
    public interface IModuleBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<ModuleDto>> GetAllSelect();
        Task<ModuleDto> GetById(int id);
        Task<Module> Save(ModuleDto entity);
        Task Update(int id, ModuleDto entity);
    }
}
