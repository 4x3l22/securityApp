using Data.Interfaces;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRoleViewBusiness
    {
        Task Delete(int id);
        Task <IEnumerable<DataSelectDto>> GetAllSelect();
        Task <Role_viewDto> GetById(int id);
        Task<Role_view> Save(Role_viewDto entity);
        Task Update(int id, Role_viewDto entity);
    }
}
