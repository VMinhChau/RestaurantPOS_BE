using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.DTOs.Order.Request;
using RestaurantPOS.DTOs.Order.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service.Implement
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrder)
        {
            using (var tr = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var newOrder = _mapper.Map<Order>(createOrder);
                    newOrder.CreateAt = DateTime.Now.ToUniversalTime();
                    await _dbContext.AddAsync(newOrder);
                    await _dbContext.SaveChangesAsync();
                    tr.Commit();
                    return _mapper.Map<OrderDto>(newOrder);
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw new Exception(ex.Message);
                }
            }

        }

        public async Task DeleteOrderAsync(int id)
        {
            using (var tr = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var order = await _dbContext.Orders.FirstOrDefaultAsync(c => c.Id == id);
                    if (order != null)
                    {
                        var orderItemsDb = await _dbContext.OrderItems.Where(c => c.OrderId == id).ToArrayAsync();
                        _dbContext.OrderItems.RemoveRange(orderItemsDb);
                        _dbContext.Orders.Remove(order);
                        _dbContext.SaveChanges();
                        tr.Commit();
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var entity = await _dbContext.Orders.ToListAsync();
            return _mapper.Map<List<OrderDto>>(entity);
        }
        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(Guid userId)
        {
            return await _dbContext.Orders
                .Where(c => c.UserId == userId)
                .Select(c => _mapper.Map<OrderDto>(c))
                .ToListAsync();
        }

        public async Task<OrderDto> UpdateOrderAsync(UpdateOrderDto updateOrder)
        {
            using (var tr = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var orderDb = await _dbContext.Orders.FirstOrDefaultAsync(c => c.Id == updateOrder.Id);
                    if (orderDb != null)
                    {
                        orderDb.PurcharseId = updateOrder.PurcharseId;
                        orderDb.Status = updateOrder.Status ?? orderDb.Status;
                        orderDb.AdminId = updateOrder.AdminId ?? orderDb.AdminId;
                        orderDb.UserId = updateOrder.UserId ?? orderDb.UserId;
                        orderDb.UpdateAt = DateTime.Now.ToUniversalTime();
                        _dbContext.Orders.Update(orderDb);
                        _dbContext.SaveChanges();
                        tr.Commit();
                        return _mapper.Map<OrderDto>(orderDb);
                    }
                    throw new Exception($"Not find order with id:{updateOrder.Id}");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
