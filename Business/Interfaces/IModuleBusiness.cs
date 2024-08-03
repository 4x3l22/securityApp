

using Data.Interfaces;
using Entity.Model.Security;

namespace Business.Interfaces
{
    public interface IModuleBusiness
    {
        Task Delete(int id);
        //Task <Module> GetAll();
        Task <IEnumerable<DataSelectDto>> GetAllSelect();
        Task <ModuleDto> GetById(int id);
        Task<Module> Save(ModuleDto entity);
        Task Update(int id, ModuleDto entity);
    }
}
