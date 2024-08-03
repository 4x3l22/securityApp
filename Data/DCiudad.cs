//public class CiudadesData : ICiudadesData
//{
//    private readonly ApplicationDbContext context;
//    protected readonly IConfiguration configuration;

//    public CiudadesData(ApplicationDbContext context, IConfiguration configuration)
//    {
//        this.context = context;
//        this.configuration = configuration;
//    }

//    public async Task Delete(int id)
//    {
//        var entity = await GetById(id);
//        if (entity == null)
//        {
//            throw new Exception("Registro no encontrado");
//        }
//        entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
//        context.Ciudades.Update(entity);
//        await context.SaveChangesAsync();
//    }

//    public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
//    {
//        var sql = @"SELECT 
//                        Id,
//                        CONCAT(Codigo, ' - ', Nombre) AS TextoMostrar 
//                    FROM 
//                        Parametro.Ciudades
//                    WHERE DeletedAt IS NULL AND Estado = 1
//                    ORDER BY Id ASC";
//        return await this.context.QueryAsync<DataSelectDto>(sql);
//    }

//    public async Task<Ciudades> GetById(int id)
//    {
//        var sql = @"SELECT * FROM parametro.Ciudades WHERE Id = @Id ORDER BY Id ASC";
//        return await this.context.QueryFirstOrDefaultAsync<Ciudades>(sql, new { Id = id });
//    }

//    public async Task<PagedListDto<CiudadesDto>> GetDataTable(QueryFilterDto filter)
//    {
//        int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
//        int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

//        var sql = @"SELECT
//                        ciu.Id,
//                        ciu.Codigo,
//                        ciu.Nombre,
//                        ciu.Estado,
//                        ciu.DepartamentoId,
//                        dep.Nombre AS Departamento
//                    FROM parametro.Ciudades ciu
//                        INNER JOIN parametro.Departamentos dep ON ciu.DepartamentoId = dep.Id
//                        WHERE ciu.DeletedAt IS NULL AND
//                        (UPPER(CONCAT(ciu.Codigo, ciu.Nombre, ciu.DepartamentoId, dep.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%')))
//                        ORDER BY '" + (filter.ColumnOrder ?? "Id") + "' " + (filter.DirectionOrder ?? "asc");

//        IEnumerable<CiudadesDto> items = await context.QueryAsync<CiudadesDto>(sql, new { Filter = filter.Filter });

//        var pagedItems = PagedListDto<CiudadesDto>.Create(items, pageNumber, pageSize);

//        return pagedItems;
//    }

//    public async Task<Ciudades> Save(Ciudades entity)
//    {
//        context.Ciudades.Add(entity);
//        await context.SaveChangesAsync();
//        return entity;
//    }

//    public async Task Update(Ciudades entity)
//    {
//        context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//        await context.SaveChangesAsync();
//    }

//    public async Task<Ciudades> GetByCode(string code)
//    {
//        return await this.context.Ciudades.AsNoTracking().Where(item => item.Codigo == code).FirstOrDefaultAsync();
//    }
//}
//tiene menú contextual