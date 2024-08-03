using Data.Interfaces;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implemenst
{
    public class DUser : User
    {
        private readonly AplicationDbContext DbContext;
        protected readonly IConfiguration configuration;

        public DUser(AplicationDbContext context, IConfiguration configuration)
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
            DbContext.Users.Update(entity);
            await DbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id,
                CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
            FROM 
                Parametro.User
            WHERE DeletedAt IS NULL AND Estado = 1
            ORDER BY Id ASC";
            return await this.DbContext.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM parametro.User WHERE Id = @Id ORDER BY Id ASC";
            return await this.DbContext.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }
        public async Task<User> Save(User entity)
        {
            DbContext.Users.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Update(User entity)
        {
            DbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }
        public async Task<User> GetByCode(int code)
        {
            return await this.DbContext.Users.AsNoTracking().FirstOrDefaultAsync(item => item.Id == code);
        }
    }
}
