using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Common;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Dtos.User.Request;
using RestaurantPOS.Dtos.User.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service.Implement
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
            try
            {
                var entity = _mapper.Map<User>(input);
                entity.PasswordHash = Utils.HashPasswords(entity.PasswordHash);
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<UserDto>(entity);
            }
            catch (Exception ex) { return new UserDto(); }
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

        public async Task<List<UserDto>> GetAsync()
        {
            var entity = await _dbContext.User
                .ToListAsync();

            return _mapper.Map<List<UserDto>>(entity);
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