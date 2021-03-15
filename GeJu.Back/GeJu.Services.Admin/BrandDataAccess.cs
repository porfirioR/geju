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
    internal class BrandDataAccess : IBrandDataAccess
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BrandDataAccess(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BrandAccessResponse> CreateAsync(BrandAccess model)
        {
            var entity = _mapper.Map<Marca>(model);
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<BrandAccessResponse>(entity) : null;
        }

        public async Task<IEnumerable<BrandAccessResponse>> GetAllAsync()
        {
            var response = await _context.Set<Marca>().Where(m => m.Activo).ProjectTo<BrandAccessResponse>(_mapper.ConfigurationProvider).ToListAsync();
            return response;
        }

        public async Task<BrandAccessResponse> GetByIdAsync(string id)
        {
            var entity = await _context.Set<Marca>().SingleOrDefaultAsync(x => x.Id == new Guid(id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Marca no existe con id: {id}");
            }
            return _mapper.Map<BrandAccessResponse>(entity);
        }

        public async Task<BrandAccessResponse> UpdateAsync(BrandAccess request)
        {
            var entity = _context.Set<Marca>().SingleOrDefault(x => x.Id == new Guid(request.Id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Marca no existe con id: {request.Id}");
            }
            var brand = _mapper.Map(request, entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<BrandAccessResponse>(entity) : null;
        }

        public async Task<BrandAccessResponse> DeleteAsync(string id)
        {
            var entity = _context.Set<Marca>().SingleOrDefault(x => x.Id == new Guid(id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Marca no existe con id: {id}");
            }
            entity.Activo = false;
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<BrandAccessResponse>(entity) : null;
        }
    }
}
