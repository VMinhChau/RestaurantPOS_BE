using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.Category.Request;
using RestaurantPOS.Dtos.Category.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly RestaurantDbContext _dbContext;
        public CategoryService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto input)
        {
            var entity = new Category()
            {
                Name = input.Name,
                Foods = new List<Food>()
            };
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Category.FindAsync(id);
            _dbContext.Category.Remove(entity!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CategoryDto> GetAsync(int id)
        {
            var entity = await _dbContext.Category
                .Include(x => x.Foods)
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<List<CategoryDto>> GetAsync()
        {
            var entity = await _dbContext.Category
                .Include(x => x.Foods)
                // .Include(x => x.Foods)
                .ToListAsync();

            return _mapper.Map<List<CategoryDto>>(entity);
        }

        public async Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto input)
        {
            var entity = await _dbContext.Category.FirstOrDefaultAsync(c => c.Id == id);

            entity.Name = input.Name;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(entity);
        }
    }
}