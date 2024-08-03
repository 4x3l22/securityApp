using Business.Interfaces;
using Data.Implemenst;
using Data.Interfaces;
using Entity.Model.Security;

namespace Business.Service
{
    public class BusinessRole : IRoleBusiness
    {
        private readonly DRole role;

        public BusinessRole(DRole role)
        {
            this.role = role;
        }
        public async Task Delete(int id)
        {
            await this.role.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.role.GetAllSelect();
        }

        public async Task<RoleDto> GetById(int id)
        {
            Role role = await this.role.GetById(id);
            RoleDto roleDto = new RoleDto();

            roleDto.Id = role.Id;
            roleDto.Description = role.Description;

            return roleDto;
        }

        public async Task<Role> Save(RoleDto entity)
        {
            Role role = new Role();
            role = this.mapearDatos(role, entity);

            return await this.role.Save(role);
        }

        public async Task Update(int id, RoleDto entity)
        {
            Role role = await this.role.GetById(id);
            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role = this.mapearDatos(role, entity);
            await this.role.Update(role);
        }

        private Role mapearDatos(Role role, RoleDto entity)
        {
            role.Id = entity.Id;
            role.Description = entity.Description;

            return role;
        }
    }
}
