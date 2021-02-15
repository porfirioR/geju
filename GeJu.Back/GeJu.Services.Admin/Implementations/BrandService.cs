using AutoMapper;
using GeJu.DALModels.Brands;
using GeJu.Services.Admin.Interfaces;
using GeJu.Sql;
using GeJu.Sql.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Implementations
{
    internal class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public BrandService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Marca> CreateAsync(CreateBrand model)
        {
            var entity = _mapper.Map<Marca>(model);
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

        public IQueryable<Marca> GetAll()
        {
            return _context.Set<Marca>().Where(m => m.Activo).AsQueryable();
        }

        public Marca GetById(Guid id)
        {
            return _context.Set<Marca>().SingleOrDefault(x => x.Id == id);
        }

        public async Task<Marca> UpdateAsync(UpdateBrand model)
        {
            var entity = GetById(model.Id);
            var brand = _mapper.Map(model, entity);
            return await _context.SaveChangesAsync() > 0 ? brand : null;
        }
    }
}
