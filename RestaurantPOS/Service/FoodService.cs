using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.Food.Request;
using RestaurantPOS.Dtos.Food.Response;
using RestaurantPOS.Interface;

namespace RestaurantPOS.Service
{
    public class FoodService : IFoodService
    {
        private readonly IMapper _mapper;
        private readonly RestaurantDbContext _dbContext;
        private readonly IFavoriteFoodService _favoriteFoodService;
        public FoodService(RestaurantDbContext dbContext, IMapper mapper, IFavoriteFoodService favoriteFoodService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _favoriteFoodService = favoriteFoodService;
        }

        public async Task<FoodDto> CreateAsync(CreateFoodDto input)
        {
            var entity = new Food()
            {
                Name = input.Name,
                Price = input.Price,
                CategoryId = input.CategoryId,
                Description = input.Description,
                Comments = new List<Comment>(),
                ImageLink = ""
            };
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<FoodDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Food.FindAsync(id);
            _dbContext.Food.Remove(entity!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FoodDto> GetAsync(int id)
        {
            var entity = await _dbContext.Food
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<FoodDto>(entity);
        }

        public async Task<List<FoodDto>> GetAsync()
        {
            var entity = await _dbContext.Food
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .ToListAsync();

            return _mapper.Map<List<FoodDto>>(entity);
        }

        public async Task<List<FoodDto>> GetAsync(Guid userId)
        {
            var favoriteFoods = await _favoriteFoodService.GetByUserIdAsync(userId);
            var favoriteFoodIds = favoriteFoods.Select(x => x.FoodId);

            var entity = await _dbContext.Food
                .Where(x => favoriteFoodIds.Contains(x.Id))
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .ToListAsync();

            return _mapper.Map<List<FoodDto>>(entity);
        }

        public async Task<FoodDto> UpdateAsync(int id, UpdateFoodDto input)
        {
            var entity = await _dbContext.Food.FirstOrDefaultAsync(c => c.Id == id);

            entity.Name = input.Name;
            entity.Price = input.Price;
            entity.CategoryId = input.CategoryId;
            entity.Description = input.Description;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<FoodDto>(entity);
        }

        public async Task UploadImageAsync(int id, string path)
        {
            var entity = await _dbContext.Food.FirstOrDefaultAsync(c => c.Id == id);

            entity.ImageLink = path;
            await _dbContext.SaveChangesAsync();
        }
    }
}