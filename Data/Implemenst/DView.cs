using Data.Interfaces;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implemenst
{
    public class DView : View
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public  DView(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.Views.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id,
                CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
            FROM 
                Parametro.View
            WHERE DeletedAt IS NULL AND Estado = 1
            ORDER BY Id ASC";
            return await this.DbContext.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM parametro.View WHERE Id = @Id ORDER BY Id ASC";
            return await this.DbContext.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
        }
        public async Task<View> Save(View entity)
        {
            DbContext.Views.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(View entity)
        {
            DbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<View> GetByCode(int code)
        {
            return await this.DbContext.Views.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }
    }
}
