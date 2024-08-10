using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Security
{
    public class DUserRol : IDUserRol
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DUserRol(AplicationDbContext context, IConfiguration configuration)
        {
            DbContext = context;
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
        public async Task<IEnumerable<UserRoleDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Userroles 
                        WHERE deleted_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<UserRoleDto>(sql);
        }
        public async Task<user_role> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Userroles WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<user_role>(sql, new { Id = id });
        }
        public async Task<user_role> Save(user_role entity)
        {
            DbContext.Userroles.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(user_role entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<user_role> GetByCode(int code)
        {
            return await DbContext.Userroles.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

    }
}
