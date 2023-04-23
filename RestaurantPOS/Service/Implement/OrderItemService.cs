using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantPOS.Data;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.DTOs.OrderItem.Request;
using RestaurantPOS.DTOs.OrderItem.Response;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Service.Implement
{
    public class OrderItemService : IOrderItemService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderItemService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderItemDto> CreateOrderItemAsync(CreateOrderItemDto createOrderItem)
        {
            using (var tr = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var currentPrice = (float)await _dbContext.Food.Where(c => c.Id == createOrderItem.FoodId).Select(c => c.Price).FirstOrDefaultAsync();
                    var orderItem = await _dbContext.OrderItems.Where(c => c.FoodId == createOrderItem.FoodId && c.OrderId == createOrderItem.OrderId).FirstOrDefaultAsync();
                    if (orderItem != null)
                    {
                        orderItem.Quatity += createOrderItem.Quatity;
                        _dbContext.OrderItems.Update(orderItem);
                        _dbContext.SaveChanges();
                        await UpdateTotalPriceAsync(orderItem.OrderId);
                        tr.Commit();
                        return _mapper.Map<OrderItemDto>(orderItem);
                    }
                    var newOrderItem = _mapper.Map<OrderItem>(createOrderItem);
                    newOrderItem.CurrrentPrice = currentPrice;
                    await _dbContext.AddAsync(newOrderItem);
                    await _dbContext.SaveChangesAsync();
                    await UpdateTotalPriceAsync(newOrderItem.OrderId);
                    tr.Commit();
                    return _mapper.Map<OrderItemDto>(newOrderItem);
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            using (var tr = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var orderItemDb = _dbContext.OrderItems.FirstOrDefault(c => c.Id == id);
                    if (orderItemDb == null) return;
                    var orderId = orderItemDb.OrderId;
                    _dbContext.OrderItems.Remove(orderItemDb);
                    _dbContext.SaveChanges();
                    await UpdateTotalPriceAsync(orderId);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task DeleteAllOrderItemByOrderIdAsync(int orderId)
        {
            using (var tr = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var orderItemsDb = await _dbContext.OrderItems.Where(c => c.OrderId == orderId).ToArrayAsync();
                    _dbContext.OrderItems.RemoveRange(orderItemsDb);
                    await _dbContext.SaveChangesAsync();
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<List<OrderItemDto>> GetOrderItemsAsync(int orderId)
        {
            var entity = await _dbContext.OrderItems.Include(c=>c.Food)
            .Where(c => c.OrderId == orderId)
            .Select(c => _mapper.Map<OrderItemDto>(c))
            .ToListAsync();
            return _mapper.Map<List<OrderItemDto>>(entity);
        }

        public async Task<OrderItemDto> UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItem)
        {
            using (var tr = _dbContext.Database.BeginTransaction())
                try
                {
                    var orderItemDb = await _dbContext.OrderItems.FirstOrDefaultAsync(c => c.Id == updateOrderItem.Id);
                    if (orderItemDb == null) return new OrderItemDto();
                    var orderIdDb = orderItemDb.OrderId;
                    orderItemDb.OrderId = updateOrderItem.OrderId ?? orderItemDb.OrderId;
                    if (updateOrderItem.FoodId != null)
                    {
                        orderItemDb.FoodId = updateOrderItem.FoodId.Value;
                        orderItemDb.CurrrentPrice = (float)await _dbContext.Food.Where(c => c.Id == updateOrderItem.FoodId).Select(c => c.Price).FirstOrDefaultAsync();
                    }
                    orderItemDb.Quatity = updateOrderItem.Quatity ?? orderItemDb.Quatity;
                    orderItemDb.Status = updateOrderItem.Status ?? orderItemDb.Status;
                    if (updateOrderItem.OrderId != null)
                    {
                        await UpdateTotalPriceAsync(orderIdDb);
                        await UpdateTotalPriceAsync(updateOrderItem.OrderId.Value);
                    }
                    await UpdateTotalPriceAsync(orderIdDb);
                    _dbContext.Update(orderItemDb);
                    _dbContext.SaveChanges();
                    tr.Commit();
                    return _mapper.Map<OrderItemDto>(orderItemDb);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
        }
        private async Task UpdateTotalPriceAsync(int orderId)
        {
            var orderItems = await _dbContext.OrderItems.Where(c => c.OrderId == orderId).ToListAsync();
            var orderDb = await _dbContext.Orders.FirstOrDefaultAsync(c => c.Id == orderId);
            if (orderDb == null) return;
            float totalPrice = 0;
            foreach (var item in orderItems)
            {
                totalPrice += (float)item.CurrrentPrice * item.Quatity;
            }
            orderDb.TotalPrice = totalPrice;
            orderDb.UpdateAt = DateTime.Now.ToUniversalTime();
            _dbContext.Update(orderDb);
            await _dbContext.SaveChangesAsync();
            return;
        }
    }
}
