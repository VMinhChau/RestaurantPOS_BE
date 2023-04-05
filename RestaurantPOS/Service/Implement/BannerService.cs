using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.Banner.Request;
using RestaurantPOS.Dtos.Banner.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service.Implement
{
    public class BannerService : IBannerService
    {
        private readonly IMapper _mapper;
        private readonly RestaurantDbContext _dbContext;
        public BannerService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BannerDto> CreateAsync(CreateBannerDto input)
        {
            var entity = new Banner()
            {
                Name = input.Name,
                ImageLink = ""
            };
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<BannerDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Banner.FindAsync(id);
            _dbContext.Banner.Remove(entity!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<BannerDto> GetAsync(int id)
        {
            var entity = await _dbContext.Banner
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<BannerDto>(entity);
        }

        public async Task<List<BannerDto>> GetAsync()
        {
            var entity = await _dbContext.Banner
                .ToListAsync();

            return _mapper.Map<List<BannerDto>>(entity);
        }

        public async Task<BannerDto> UpdateAsync(int id, UpdateBannerDto input)
        {
            var entity = await _dbContext.Banner.FirstOrDefaultAsync(c => c.Id == id);

            entity.Name = input.Name;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<BannerDto>(entity);
        }

        public async Task UploadImageAsync(int id, string path)
        {
            var entity = await _dbContext.Banner.FirstOrDefaultAsync(c => c.Id == id);

            entity.ImageLink = path;
            await _dbContext.SaveChangesAsync();
        }
    }
}