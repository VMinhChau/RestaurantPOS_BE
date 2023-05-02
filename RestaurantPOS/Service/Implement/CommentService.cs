using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.Comment.Request;
using RestaurantPOS.Dtos.Comment.Response;
using RestaurantPOS.Dtos.Food.Response;
using RestaurantPOS.Dtos.User.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service.Implement
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly RestaurantDbContext _dbContext;
        public CommentService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateAsync(CreateCommentDto input)
        {
            var entity = new Comment()
            {
                Rating = input.Rating,
                Content = input.Content,
                FoodId = input.FoodId,
                UserId = input.UserId
            };
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CommentDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Comment.FindAsync(id);
            _dbContext.Comment.Remove(entity!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CommentDto> UpdateAsync(int id, UpdateCommentDto input)
        {
            var entity = await _dbContext.Comment.FirstOrDefaultAsync(c => c.Id == id);

            entity.Rating = input.Rating;
            entity.Content = input.Content;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CommentDto>(entity);
        }

        public async Task<List<CommentDto>> GetAsync()
        {
            var e = await _dbContext.Comment.ToListAsync();
            var entity = _mapper.Map<List<CommentDto>>(e);
            var u =_dbContext.User.AsNoTracking().ToList();
            var user = _mapper.Map<List<UserDto>>(u);
            var f =_dbContext.Food.AsNoTracking().ToList();
            var food = _mapper.Map<List<FoodDto>>(f);
            foreach(var item in entity){
                item.FirstName = user.Single(x => x.Id == item.UserId).FirstName;
                item.LastName = user.Single(x => x.Id == item.UserId).LastName;
                item.FoodNavigation = food.Single(x => x.Id == item.FoodId);
            }
            return entity;
        }

        public async Task<List<CommentDto>> GetComments() {
            var entity = await _dbContext.Comment
                .Include(x => x.User)
                .ToListAsync();
            return _mapper.Map<List<CommentDto>>(entity);
        }
    }
}