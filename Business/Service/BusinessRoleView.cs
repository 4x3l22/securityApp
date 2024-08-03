using Business.Interfaces;
using Data.Implemenst;
using Data.Interfaces;
using Entity.Model.Security;

namespace Business.Service
{
    public class BusinessRoleView : IRoleViewBusiness
    {
        private readonly DRole_view dRole_View;

        public BusinessRoleView(DRole_view role_View)
        {
            this.dRole_View = dRole_View;
        }
        public async Task Delete(int id)
        {
            await this.dRole_View.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.dRole_View.GetAllSelect();
        }

        public async Task<Role_viewDto> GetById(int id)
        {
            Role_view role_View = await this.dRole_View.GetById(id);
            Role_viewDto role_ViewDto = new Role_viewDto();

            role_ViewDto.Id = role_View.Id;
            role_ViewDto.IdRole = role_View.IdRole;
            role_ViewDto.IdView = role_View.IdView;
            role_ViewDto.state = role_View.state;

            return role_ViewDto;
        }

        public async Task<Role_view> Save(Role_viewDto entity)
        {
            Role_view role_View = new Role_view();
            role_View = this.mapearDatos(role_View, entity);

            return await this.dRole_View.Save(role_View);
        }

        public async Task Update(int id, Role_viewDto entity)
        {
            Role_view role_View = await this.dRole_View.GetById(id);
            if (role_View == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role_View = this.mapearDatos(role_View, entity);
            await this.dRole_View.Update(role_View);
        }

        private Role_view mapearDatos(Role_view role_View, Role_viewDto entity)
        {
            role_View.Id = entity.Id;
            role_View.IdRole = entity.IdRole;
            role_View.IdView = entity.IdView;
            role_View.state = entity.state;

            return role_View;
        }
    }
}
