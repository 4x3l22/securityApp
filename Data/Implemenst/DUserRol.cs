using Data.Interfaces;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst
{
    public class DUserRol : user_role
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DUserRol(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.Userroles.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id,
                CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
            FROM 
                Parametro.UserRol
            WHERE DeletedAt IS NULL AND Estado = 1
            ORDER BY Id ASC";
            return await this.DbContext.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<user_role> GetById(int id)
        {
            var sql = @"SELECT * FROM parametro.UserRol WHERE Id = @Id ORDER BY Id ASC";
            return await this.DbContext.QueryFirstOrDefaultAsync<user_role>(sql, new { Id = id });
        }
        public async Task<user_role> Save(user_role entity)
        {
            DbContext.Userroles.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(user_role entity)
        {
            DbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<user_role> GetByCode(int code)
        {
            return await this.DbContext.Userroles.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }
    }
}
