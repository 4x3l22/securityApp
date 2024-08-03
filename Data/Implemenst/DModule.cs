using Microsoft.EntityFrameworkCore;
using Entity.Model.Context;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst
{
    public class DModule
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DModule(AplicationDbContext context, IConfiguration configuration)
        {
            this.DbContext = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            DbContext.Modules.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
                    FROM 
                        Parametro.Module
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await this.DbContext.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Entity.Model.Security.Module> GetById(int id)
        {
            var sql = @"SELECT * FROM parametro.Module WHERE Id = @Id ORDER BY Id ASC";
            return await this.DbContext.QueryFirstOrDefaultAsync<Entity.Model.Security.Module>(sql, new { Id = id });
        }

        public async Task<Entity.Model.Security.Module> Save(Entity.Model.Security.Module entity)
        {
            DbContext.Modules.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Entity.Model.Security.Module entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task<Entity.Model.Security.Module> GetByCode(int code)
        {
            return await this.DbContext.Modules.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }
    }
}
