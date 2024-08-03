using Data.Interfaces;
using Entity.Model.Security;

namespace Business.Interfaces
{
    public interface IUserBisness
    {
        Task Delete(int id);
        Task <IEnumerable<DataSelectDto>> GetAllSelect();
        Task <UserDto> GetById(int id);
        Task<User> Save(UserDto entity); 
        Task Update(int id, UserDto entity);
    }
}
