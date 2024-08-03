using Business.Interfaces;
using Data.Implemenst;
using Data.Interfaces;
using Entity.Model.Security;

namespace Business.Service
{
    public class BusinessUserRole : IUserRoleBusiness
    {
        private readonly DUserRol dUserRole;

        public BusinessUserRole(DUserRol userRol)
        {
            this.dUserRole = dUserRole;
        }
        public async Task Delete(int id)
        {
            await this.dUserRole.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.dUserRole.GetAllSelect();
        }

        public async Task<UserRoleDto> GetById(int id)
        {
            user_role userRole = await this.dUserRole.GetById(id);
            UserRoleDto userRoleDto = new UserRoleDto();

            userRoleDto.Id = userRole.Id;
            userRoleDto.IdRole = userRole.IdRole;
            userRoleDto.IdUser = userRole.IdUser;
            userRoleDto.state = userRole.state;

            return userRoleDto;
        }

        public async Task<user_role> Save(UserRoleDto entity)
        {
            user_role userRole = new user_role();
            userRole = this.mapearDatos(userRole, entity);

            return await this.dUserRole.Save(userRole);
        }

        public async Task Update(int id, UserRoleDto entity)
        {
            user_role user_Role = await this.dUserRole.GetById(id);
            if (user_Role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user_Role = this.mapearDatos(user_Role, entity);
            await this.dUserRole.Update(user_Role);
        }

        private user_role mapearDatos(user_role user_Role, UserRoleDto entity)
        {
            user_Role.Id = entity.Id;
            user_Role.IdRole = entity.IdRole;
            user_Role.IdUser = entity.IdUser;
            user_Role.state = entity.state;

            return user_Role;
        }
    }
}
