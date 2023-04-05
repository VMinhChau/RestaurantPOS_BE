using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.FavoriteFood.Request;
using RestaurantPOS.Dtos.FavoriteFood.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service.Implement
{
    public class FavoriteFoodService : IFavoriteFoodService
    {
        private readonly IMapper _mapper;
        private readonly RestaurantDbContext _dbContext;
        public FavoriteFoodService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FavoriteFoodDto> CreateAsync(CreateFavoriteFoodDto input)
        {
            var entity = new FavoriteFood()
            {
                FoodId = input.FoodId,
                UserId = input.UserId
            };
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<FavoriteFoodDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.FavoriteFood.FindAsync(id);
            _dbContext.FavoriteFood.Remove(entity!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<FavoriteFoodDto>> GetByUserIdAsync(Guid userId)
        {
            var entity = await _dbContext.FavoriteFood
                    .Where(x => x.UserId == userId)
                    .ToListAsync();

            return _mapper.Map<List<FavoriteFoodDto>>(entity);
        }
    }
}