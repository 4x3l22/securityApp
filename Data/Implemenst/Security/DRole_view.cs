using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Security
{
    public class DRole_view : IDRoleView
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DRole_view(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.RoleView.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Role_viewDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Roleview 
                        WHERE delete_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<Role_viewDto>(sql);
        }
        public async Task<Role_view> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Roleview WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<Role_view>(sql, new { Id = id });
        }
        public async Task<Role_view> Save(Role_view entity)
        {
            DbContext.RoleView.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Role_view entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<Role_view> GetByCode(int code)
        {
            return await DbContext.RoleView.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

        public async Task<MenuDto> Menu(int id)
        {
            var sql = @"SELECT 
                v.name AS ViewName, 
                m.name AS ModuleName, 
                v.id AS viewId,
                m.id AS moduleId
                FROM dbo.RoleView AS rv
                INNER JOIN dbo.[Views] AS v ON v.id = rv.ViewId
                INNER JOIN dbo.[Modules] AS m ON m.id = v.moduleId
                WHERE rv.id = @Id;";

            // Ejecutar la consulta y mapear los resultados a MenuDto
            return await DbContext.QueryFirstOrDefaultAsync<MenuDto>(sql, new { Id = id });
        }

    }
}
