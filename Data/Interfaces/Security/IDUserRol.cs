using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces.Security
{
    public interface IDUserRol
    {
        Task Delete(int id);
        Task<IEnumerable<UserRoleDto>> GetAllSelect();
        Task<user_role> GetById(int id);
        Task<user_role> Save(user_role entity);
        Task Update(user_role entity);
        Task<user_role> GetByCode(int code);
    }
}
