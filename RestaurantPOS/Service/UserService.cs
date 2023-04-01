using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Core.Enums;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.User.Request;
using RestaurantPOS.Dtos.User.Response;
using RestaurantPOS.Interface;

namespace RestaurantPOS.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly RestaurantDbContext _dbContext;
        public UserService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto input)
        {
            var entity = new User()
            {
                LastName = input.LastName,
                FirstName = input.FirstName,
                Birthday = input.Birthday,
                Email = input.Email,
                Gender = input.Gender,
                PhoneNumber = input.PhoneNumber,
                Points = 0,
                Ranking = RankUser.Bronze,
                ImageLink = ""
            };
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<UserDto>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbContext.User.FindAsync(id);
            _dbContext.User.Remove(entity!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var entity = await _dbContext.User.FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> UpdateAsync(Guid id, UpdateUserDto input)
        {
            var entity = await _dbContext.User.FirstOrDefaultAsync(c => c.Id == id);

            entity.LastName = input.LastName;
            entity.FirstName = input.FirstName;
            entity.Birthday = input.Birthday;
            entity.Email = input.Email;
            entity.Gender = input.Gender;
            entity.PhoneNumber = input.PhoneNumber;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(entity);
        }

        public async Task UploadImageAsync(Guid id, string path)
        {
            var entity = await _dbContext.User.FirstOrDefaultAsync(c => c.Id == id);

            entity.ImageLink = path;
            await _dbContext.SaveChangesAsync();
        }
    }
}