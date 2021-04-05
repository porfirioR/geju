using Access.Contract.Interfaces;
using Access.Contract.Request;
using Access.Contract.Response;
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
    internal class ColorDataAccess : IColorDataAccess
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ColorDataAccess(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ColorAccessResponse> CreateAsync(ColorAccess request)
        {
            var entity = _mapper.Map<Color>(request);
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<ColorAccessResponse>(entity) : null;
        }

        public async Task<ColorAccessResponse> DeleteAsync(string id)
        {
            var entity = _context.Set<Color>().SingleOrDefault(x => x.Id == new Guid(id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Color no existe con id: {id}");
            }
            entity.Activo = false;
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<ColorAccessResponse>(entity) : null;
        }

        public async Task<IEnumerable<ColorAccessResponse>> GetAllAsync()
        {
            var response = await _context.Set<Color>().Where(m => m.Activo).ProjectTo<ColorAccessResponse>(_mapper.ConfigurationProvider).ToListAsync();
            return response;
        }

        public async Task<ColorAccessResponse> GetByIdAsync(string id)
        {
            var entity = await _context.Set<Color>().SingleOrDefaultAsync(x => x.Id == new Guid(id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Color no existe con id: {id}");
            }
            return _mapper.Map<ColorAccessResponse>(entity);
        }

        public async Task<ColorAccessResponse> UpdateAsync(ColorAccess request)
        {
            var entity = _context.Set<Color>().SingleOrDefault(x => x.Id == new Guid(request.Id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Color no existe con id: {request.Id}");
            }
            var brand = _mapper.Map(request, entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<ColorAccessResponse>(entity) : null;
        }
    }
}
