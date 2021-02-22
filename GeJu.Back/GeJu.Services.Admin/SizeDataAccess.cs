using Access.Contract.Request;
using Access.Contract.Response;
using Admin.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GeJu.Sql;
using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin
{
    internal class SizeDataAccess : ISizeDataAccess
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public SizeDataAccess(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<SizeAccessResponse> CreateAsync(SizeAccess model)
        {
            var entity = _mapper.Map<Tamaño>(model);
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<SizeAccessResponse>(entity) : null;
        }

        public async Task<IEnumerable<SizeAccessResponse>> GetAllAsync()
        {
            var response = await _context.Set<Tamaño>().Where(m => m.Activo).ProjectTo<SizeAccessResponse>(_mapper.ConfigurationProvider).ToListAsync();
            return response;
        }

        public async Task<SizeAccessResponse> GetByIdAsync(string id)
        {
            var entity = await _context.Set<Tamaño>().SingleOrDefaultAsync(x => x.Id == new Guid(id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Tamaño no existe con id: {id}");
            }
            return _mapper.Map<SizeAccessResponse>(entity);
        }

        public async Task<SizeAccessResponse> UpdateAsync(SizeAccess request)
        {
            var entity = await _context.Set<Tamaño>().SingleOrDefaultAsync(x => x.Id == new Guid(request.Id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Tamaño no existe con id: {request.Id}");
            }
            var brand = _mapper.Map(request, entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<SizeAccessResponse>(entity) : null;
        }

        public async Task<SizeAccessResponse> DeleteAsync(string id)
        {
            var entity = await _context.Set<Tamaño>().SingleOrDefaultAsync(x => x.Id == new Guid(id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Tamaño no existe con id: {id}");
            }
            entity.Activo = false;
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<SizeAccessResponse>(entity) : null;
        }
    }
}
