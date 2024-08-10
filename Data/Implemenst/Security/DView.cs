using Data.Interfaces.Security;
using Entity.Dto;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst.Security
{
    public class DView : IDView
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DView(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.Views.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<ViewDto>> GetAllSelect()
        {
            var sql = @"SELECT * FROM dbo.Views 
                        WHERE deleted_at IS NULL
                        AND state = 1
                        ORDER BY Id ASC";
            return await DbContext.QueryAsync<ViewDto>(sql);
        }
        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Views WHERE Id = @Id ORDER BY Id ASC";
            return await DbContext.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
        }
        public async Task<View> Save(View entity)
        {
            DbContext.Views.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(View entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<View> GetByCode(int code)
        {
            return await DbContext.Views.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }

    }
}
