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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    internal class UserDataAccess : IUserDataAccess
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserDataAccess(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserAccessResponse> CreateAsync(UserAccess model)
        {
            var entity = _mapper.Map<Usuario>(model);
            await _context.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
            {
                var user = _mapper.Map<UserAccessResponse>(entity);
                return user;
            }
            return null;
        }

        public async Task<UserAccessResponse> GetByIdAsync(string id)
        {
            var model = await _context.Set<Usuario>().SingleOrDefaultAsync(x => x.Id == new Guid(id));
            if (model is null)
            {
                throw new KeyNotFoundException($"id {id}");
            }
            return _mapper.Map<UserAccessResponse>(model);
        }

        public async Task<IEnumerable<UserAccessResponse>> GetAllAsync()
        {
            var userList = await _context.Set<Usuario>().Where(u => u.Activo).ProjectTo<UserAccessResponse>(_mapper.ConfigurationProvider).ToListAsync();
            return userList;
        }

        public async Task<UserAccessResponse> UpdateAsync(UserAccess model)
        {
            var entity = await _context.Set<Usuario>().SingleOrDefaultAsync(x => x.Id == new Guid(model.Id));
            if (entity is null)
            {
                throw new KeyNotFoundException($"id {entity.Id}");
            }
            entity = _mapper.Map(model, entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<UserAccessResponse>(entity) : null;
        }

        public async Task<UserAccessResponse> RegisterAsync(UserAccess model)
        {
            var entity = _mapper.Map<Usuario>(model);
            using var hmac = new HMACSHA512();
            entity.ContraseñaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
            entity.ContraseñaSalt = hmac.Key;
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<UserAccessResponse>(entity) : null;
        }

        public async Task<UserAccessResponse> DeleteAsync(string id)
        {
            var model = _context.Set<Usuario>().SingleOrDefault(x => x.Id == new Guid(id));
            if (model is null)
            {
                throw new KeyNotFoundException($"id {id}");
            }
            model.Activo = false;
            _context.Update(model);
            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<UserAccessResponse>(model) : null;
        }
    }
}
