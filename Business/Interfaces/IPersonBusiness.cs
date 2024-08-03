using Data.Interfaces;
using Entity.Model.Security;

namespace Business.Interfaces
{
    public interface IPersonBusiness
    {
        Task Delete(int id);
        Task <IEnumerable<DataSelectDto>> GetAllSelect();
        Task <PersonDto> GetById(int id);
        Task<Person> Save(PersonDto entity);
        Task Update(int id, PersonDto entity);
    }
}
