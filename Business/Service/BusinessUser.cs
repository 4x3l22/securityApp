using Business.Interfaces;
using Data.Implemenst;
using Data.Interfaces;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class BusinessUser : IUserBisness
    {
        private readonly DUser dUser;

        public BusinessUser(DUser dUser)
        {
            this.dUser = dUser;
        }
        public async Task Delete(int id)
        {
            await this.dUser.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.dUser.GetAllSelect();
        }

        public async Task<UserDto> GetById(int id)
        {
            User user = await this.dUser.GetById(id);
            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.UserName = user.UserName;
            userDto.passsword = user.passsword;
            userDto.PersonId = user.PersonId;
            userDto.state = user.state;

            return userDto;
        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user = this.mapearDatos(user, entity);

            return await this.dUser.Save(user);
        }

        public async Task Update(int id, UserDto entity)
        {
            User user = await this.dUser.GetById(id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = this.mapearDatos(user, entity);
            await this.dUser.Update(user);
        }

        private User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.UserName = entity.UserName;
            user.passsword = entity.passsword;
            user.PersonId = entity.PersonId;
            user.state = entity.state;

            return user;
        }
    }
}
