using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using BlazorBlog.Models;
using BlazorBlog.Models.Tables;
using ClosedXML;
using Microsoft.EntityFrameworkCore;
using ms_newgat_commesse.Attributes;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;

namespace BlazorBlog.Services
{
    public class CrudHandler
    {
        private readonly BlogDBContext context;
        private readonly ILogger<CrudHandler> logger;
        private readonly IMapper mapper;
        private readonly CachingService cachingService;



        public CrudHandler(BlogDBContext context,
        ILogger<CrudHandler> logger,
        IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }


        public async Task<DTO> Get<DTO, Table>(int id) where Table : GenericTable
        {
            return await Get<DTO, Table>(id, CancellationToken.None);
        }

        public async Task<DTO> Get<DTO, Table>(int id, CancellationToken cancellationToken) where Table : GenericTable
        {
            DTO? entity;
            var query = GetQueryable<Table>()
                .Where(x => x.id == id)
                .ProjectTo<DTO>(mapper.ConfigurationProvider);
            bool isCached = typeof(Table).GetCustomAttribute<CacheableAttribute>() != null;
            if (isCached)
            {
                entity = query.FirstOrDefault();
            }
            else
            {
                entity = await query.FirstOrDefaultAsync(cancellationToken);
            }

            if (entity == null)
            {
                var displayName = typeof(Table).GetCustomAttribute<DisplayNameAttribute>();
                string entityName = displayName?.DisplayName ?? typeof(Table).Name;
                throw new KeyNotFoundException($"Richiesta per {entityName} {id} inesistente");
            }

            return entity;
        }

        public async Task<ResultList<DTO>> GetList<DTO, Table>(ListFilter filter) where Table : class
        {
            return await GetList<DTO, Table>(filter);
        }

        public async Task<DTO> Insert<DTO, UpdateDTO, Table>(UpdateDTO data) where Table : class
        {
            var entity = mapper.Map<Table>(data);
            context.Add(entity);
            await context.SaveChangesAsync();
            return mapper.Map<DTO>(entity);
        }

        public async Task Delete<Table>(int id) where Table : class
        {
            var entity = await context.Set<Table>()
                .FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);

            if (entity == null)
                throw new KeyNotFoundException($"Entità con ID {id} non trovata.");

            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<DTO> Update<DTO, UpdateDTO, Table>(int Id, UpdateDTO data) where Table : GenericTable
        {
            var result = await Update<DTO, UpdateDTO, Table>(Id, data, CancellationToken.None);
            return result;
        }

        public async Task<DTO> Update<DTO, UpdateDTO, Table>(int Id, UpdateDTO data,
       CancellationToken cancellationToken) where Table : GenericTable
        {
            Table? entity = await GetQueryable<Table>()
                .FirstOrDefaultAsync(x => x.id == Id, cancellationToken);

            if (entity == null)
            {
                var displayName = typeof(Table).GetCustomAttribute<DisplayNameAttribute>();
                string entityName = displayName?.DisplayName ?? typeof(Table).Name;
                string message = $"Richiesta di aggiornamento per entità {entityName} {Id} inesistente";
                throw new KeyNotFoundException(message);
            }

            mapper.Map(data, entity);
            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<DTO>(entity);
        }

        public IQueryable<Table> GetQueryable<Table>() where Table : class
        {
            CacheableAttribute? chacheable = typeof(Table).GetCustomAttribute<CacheableAttribute>();
            IQueryable<Table> query = context.Set<Table>().AsQueryable();

            return query;
        }

    }
}
