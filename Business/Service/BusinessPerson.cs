using Business.Interfaces;
using Data.Implemenst;
using Data.Interfaces;
using Entity.Model.Security;


namespace Business.Service
{

    public class BusinessPerson : IPersonBusiness
    {
        private readonly DPerson person;

        public BusinessPerson(DPerson person)
        {
            this.person = person;
        }
        public async Task Delete(int id)
        {
            await this.person.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.person.GetAllSelect();
        }

        public async Task<PersonDto> GetById(int id)
        {
            Person module = await this.person.GetById(id);
            PersonDto personDto = new PersonDto();

            personDto.Id = person.Id;
            personDto.first_name = person.first_name;
            personDto.last_name = person.last_name;
            personDto.email = person.email;
            personDto.gender = person.gender;
            personDto.document = person.document;
            personDto.type_document = person.type_document;
            personDto.direction = person.direction;
            personDto.phone = person.phone;
            personDto.birthday = person.birthday;

            return personDto;
        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person();
            person = this.mapearDatos(person, entity);

            return await this.person.Save(person);
        }

        public async Task Update(int id, PersonDto entity)
        {
            Person person = await this.person.GetById(id);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = this.mapearDatos(person, entity);
            await this.person.Update(person);
        }

        private Person mapearDatos(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.first_name = entity.first_name;
            person.last_name = entity.last_name;
            person.email = entity.email;
            person.gender = entity.gender;
            person.document = entity.document;
            person.type_document = entity.type_document;
            person.direction = entity.direction;
            person.phone = entity.phone;
            person.birthday = entity.birthday;

            return person;
        }
    }
}
