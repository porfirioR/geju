using AutoMapper;
using GeJu.AccessServicesModel.Sizes;
using GeJu.Services.Admin.Interfaces;
using GeJu.Sql;
using GeJu.Sql.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Implementations
{
    internal class SizesServices : ISizesServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public SizesServices(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Tamaño> CreateAsync(CreateSize model)
        {
            var entity = _mapper.Map<Tamaño>(model);
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity : null;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = GetById(id);
            entity.Activo = false;
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Tamaño> GetAll()
        {
            return _context.Set<Tamaño>().Where(m => m.Activo).AsQueryable();
        }

        public Tamaño GetById(Guid id)
        {
            return _context.Set<Tamaño>().SingleOrDefault(x => x.Id == id);
        }

        public async Task<Tamaño> UpdateAsync(UpdateSize model)
        {
            var entity = GetById(model.Id);
            var brand = _mapper.Map(model, entity);
            return await _context.SaveChangesAsync() > 0 ? brand : null;
        }
    }
}
