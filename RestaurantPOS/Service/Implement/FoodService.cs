using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.Category.Response;
using RestaurantPOS.Dtos.Food.Request;
using RestaurantPOS.Dtos.Food.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service.Implement
{
    public class FoodService : IFoodService
    {
        private readonly IMapper _mapper;
        private readonly RestaurantDbContext _dbContext;
        private readonly IFavoriteFoodService _favoriteFoodService;
        private readonly IWebHostEnvironment _webhost;
        public FoodService(RestaurantDbContext dbContext, IMapper mapper, IFavoriteFoodService favoriteFoodService, IWebHostEnvironment webhost)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _favoriteFoodService = favoriteFoodService;
            _webhost = webhost;
        }

        public async Task<FoodDto> CreateAsync(CreateFoodDto input)
        {
            var filename = Path.GetFileName(input.ImageFile.FileName);
            var directory = Path.Combine("Content", $"Food\\");
            var path = Path.Combine(_webhost.WebRootPath, directory, filename);

            // Create the directory if it does not exist
            Directory.CreateDirectory(directory);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await input.ImageFile.CopyToAsync(stream);
            }

           

            var entity = new Food()
            {
                Name = input.Name,
                Price = input.Price,
                IsPromotion = input.IsPromotion,
                CategoryId = input.CategoryId,
                Description = input.Description,
                Comments = new List<Comment>(),
                ImageLink = path
                
            };
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<FoodDto>(entity);
        }

        public List<CategoryDto> GetCate()
        {
            var entity =  _dbContext.Category.ToList();

            return _mapper.Map<List<CategoryDto>>(entity);
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
                .Include(x => x.Categories)
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<FoodDto>(entity);
        }

        public async Task<List<FoodDto>> GetSuggestAsync(int id)
        {
            var food = await GetAsync(id);
            var entity = await _dbContext.Food
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .Where(p => p.CategoryId != food!.CategoryId)
                .GroupBy(p => p.CategoryId)
                .Select(g => g.FirstOrDefault())
                .ToListAsync();

            return _mapper.Map<List<FoodDto>>(entity);
        }

        public async Task<List<FoodDto>> GetAsync()
        {
            var entity = await _dbContext.Food
                .Include(x => x.CategoryNavigation)
                // .Include(x => x.Categories)
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .ToListAsync();

            return _mapper.Map<List<FoodDto>>(entity);
        }

        public async Task<List<FoodDto>> GetPromotionAsync()
        {
            var entity = await _dbContext.Food
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .Where(x => x.IsPromotion)
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
            // var filename = Path.GetFileName(input.ImageFile.FileName);
            // var directory = Path.Combine("Content", $"Food\\{id}");
            // var path = Path.Combine(_webhost.WebRootPath, directory, filename);

            // // Create the directory if it does not exist
            // Directory.CreateDirectory(directory);

            // using (var stream = new FileStream(path, FileMode.Create))
            // {
            //     await input.ImageFile.CopyToAsync(stream);
            // }

            // await UploadImageAsync(id, path);

            var entity = await _dbContext.Food.FirstOrDefaultAsync(c => c.Id == id);

            entity.Name = input.Name;
            entity.Price = input.Price;
            entity.IsPromotion = input.IsPromotion;
            entity.CategoryId = input.CategoryId;
            entity.Description = input.Description;
            entity.ImageLink = "";

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<FoodDto>(entity);
        }

        // public async Task AddImageAsync(string path) 
        // {
        //     var entity = await _dbContext.Food;
        //     entity.ImageLink = path;
        //     await _dbContext.SaveChangesAsync();
        // }
        public async Task UploadImageAsync(int id, string path)
        {
            var entity = await _dbContext.Food.FirstOrDefaultAsync(c => c.Id == id);

            entity.ImageLink = path;
            await _dbContext.SaveChangesAsync();
        }
    }
}