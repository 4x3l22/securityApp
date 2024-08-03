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
    public class DRole_view : Role_view
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DRole_view(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.RoleView.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id,
                CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
            FROM 
                Parametro.RoleView
            WHERE DeletedAt IS NULL AND Estado = 1
            ORDER BY Id ASC";
            return await this.DbContext.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Role_view> GetById(int id)
        {
            var sql = @"SELECT * FROM parametro.Roleview WHERE Id = @Id ORDER BY Id ASC";
            return await this.DbContext.QueryFirstOrDefaultAsync<Role_view>(sql, new { Id = id });
        }
        public async Task<Role_view> Save(Role_view entity)
        {
            DbContext.RoleView.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Role_view entity)
        {
            DbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<Role_view> GetByCode(int code)
        {
            return await this.DbContext.RoleView.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }
    }
}
