using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Controllers;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.Models;
using RestaurantPOS.Models.Create;
using RestaurantPOS.Models.Update;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service
{
    public class UserService:IUserService
    {
        private readonly RestaurantDbContext _dbContext;
        public UserService(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> CreateUserAsync(CreateUserModel input)
        {
            var userNew = new User()
            {
                
            };
            await _dbContext.AddAsync(userNew);
            await _dbContext.SaveChangesAsync();
            return userNew;
        }
        public async Task<User?> UpdateUserAsync(UpdateUserModel input)
        {
            var userDb = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == input.Id);
            if (userDb == null)
            {
                return null;
            }
            await _dbContext.SaveChangesAsync();
            return userDb;
        }

        public async Task DeleteUserAsync(int id)
        {
            var userDb = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (userDb == null)
            {
                return;
            }
            _dbContext.Users.Remove(userDb);
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUserAsync()
        {
            return await _dbContext.Users.Select(c=>new UserViewModel(){
            }).ToListAsync();
        }

        public async Task<UserViewModel?> GetOneUserAsync(int id)
        {
            return await _dbContext.Users.Where(c=>c.Id==id).Select(c => new UserViewModel()
            {
            }).FirstOrDefaultAsync();
        }
    }
}
