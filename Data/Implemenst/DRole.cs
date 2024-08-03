using Data.Interfaces;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst
{
    public class DRole : Role
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DRole(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.Role.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id,
                CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
            FROM 
                Parametro.Role
            WHERE DeletedAt IS NULL AND Estado = 1
            ORDER BY Id ASC";
            return await this.DbContext.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM parametro.Role WHERE Id = @Id ORDER BY Id ASC";
            return await this.DbContext.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }
        public async Task<Role> Save(Role entity)
        {
            DbContext.Role.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Role entity)
        {
            DbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<Role> GetByCode(int code)
        {
            return await this.DbContext.Role.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }
    }
}
