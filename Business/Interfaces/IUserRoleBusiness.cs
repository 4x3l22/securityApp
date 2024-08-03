using Data.Interfaces;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserRoleBusiness
    {
        Task Delete(int id);
        Task <IEnumerable<DataSelectDto>> GetAllSelect();
        Task <UserRoleDto> GetById(int id);
        Task<user_role> Save(UserRoleDto entity); 
        Task Update(int id, UserRoleDto entity);
    }
}
