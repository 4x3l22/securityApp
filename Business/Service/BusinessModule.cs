using Business.Interfaces;
using Data.Implemenst;
using Data.Interfaces;
using Entity.Model.Security;

namespace Business.Service
{
    public class BusinessModule : IModuleBusiness
    {
        private readonly DModule module;

        public BusinessModule(DModule module)
        {
            this.module = module;
        }
        public async Task Delete(int id)
        {
            await  this.module.Delete(id);
        }

        //public Task<Module> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.module.GetAllSelect();
        }

        public async Task<ModuleDto> GetById(int id)
        {
            Module module = await this.module.GetById(id);
            ModuleDto moduleDto = new ModuleDto();

            moduleDto.Id = module.Id;
            moduleDto.Name = module.Name;
            moduleDto.Description = module.Description;

            return moduleDto;
        }

        public async Task<Module> Save(ModuleDto entity)
        {
            Module module = new Module();
            module = this.mapearDatos(module, entity);

            return await this.module.Save(module);
        }

        public async Task Update(int id, ModuleDto entity)
        {
            Module module = await this.module.GetById(id);
            if(module == null)
            {
                throw new Exception("Registro no encontrado");
            }
            module = this.mapearDatos(module,entity);
            await this.module.Update(module);
        }
        private Module mapearDatos(Module module, ModuleDto entity)
        {
            module.Id = entity.Id;
            module.Name = entity.Name;
            module.Description = entity.Description;

            return module;
        }
    }
}
