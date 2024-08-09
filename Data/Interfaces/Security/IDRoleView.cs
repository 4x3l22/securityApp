using Entity.Dao;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Security
{
    public interface IDRoleView
    {
        Task Delete(int id);
        Task<IEnumerable<Role_viewDto>> GetAllSelect();
        Task<Role_view> GetById(int id);
        Task<Role_view> Save(Role_view entity);
        Task Update(Role_view entity);
        Task<Role_view> GetByCode(int code);
        Task<MenuDto> Menu(int id);
    }
}
