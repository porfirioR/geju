using Access.Contract.Admin.Interfaces;
using Access.Contract.Admin.Request;
using Access.Contract.Admin.Response;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GeJu.Sql;
using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Resources.Contract.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin
{
    public class PermissionDataAccess : IPermissionDataAccess
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PermissionDataAccess(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionAccessResponse>> GetAllAsync()
        {
            var response = await _context.Set<Permiso>()
                .ProjectTo<PermissionAccessResponse>(_mapper.ConfigurationProvider).ToListAsync();
            return response;
        }

        public async Task<PermissionAccessResponse> UpdateAsync(PermissionAccess request)
        {
            var entity = _context.Set<Permiso>().SingleOrDefault(x => x.Id == new Guid(request.Id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Permiso no existe con id: {request.Id}");
            }
            var brand = _mapper.Map(request, entity);
            _context.Update(brand);
            await _context.SaveChangesAsync();
            return _mapper.Map<PermissionAccessResponse>(entity);
        }

        public async Task<PermissionAccessResponse> DeleteAsync(string id)
        {
            var entity = _context.Set<Permiso>().SingleOrDefault(x => x.Id == new Guid(id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Permiso no existe con id: {id}");
            }
            entity.Activo = false;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PermissionAccessResponse>(entity);
        }

        public async Task<PermissionAccessResponse> ActivateAsync(string id)
        {
            var entity = _context.Set<Permiso>().SingleOrDefault(x => x.Id == new Guid(id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"Permiso no existe con id: {id}");
            }
            entity.Activo = true;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PermissionAccessResponse>(entity);
        }

        public async Task<PermissionAccessResponse> GetByIdAsync(string id)
        {
            var entity = await _context.Set<Permiso>().SingleOrDefaultAsync(x => x.Id == new Guid(id));
            var response = _mapper.Map<PermissionAccessResponse>(entity);
            return response ?? throw new KeyNotFoundException($"Permiso no existe con id: {id}");
        }
    }
}
