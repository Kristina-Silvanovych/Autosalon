using autosalon.Data;
using autosalon.Models;
using autosalon.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace autosalon.Services
{
    public class OrderService:IOrderService
    {
        private readonly AutoSalonDBContext dbContext;

        public OrderService(AutoSalonDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await this.dbContext.Orders.ToListAsync();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            this.dbContext.Orders.Add(order);
            await this.dbContext.SaveChangesAsync();

            return order;
        }

        async Task<bool> IOrderService.DeleteOrder(int id)
        {
            var order = await this.dbContext.Orders.FindAsync(id);

            if (order == null)
            {
                return false;
            }

            dbContext.Orders.Remove(order);

            await dbContext.SaveChangesAsync();

            return true;
        }

        async Task<bool> IOrderService.ChangeOrder(int id, Order updatedOrder)
        {
            var order = await this.dbContext.Orders.FindAsync(id);

            if (order == null)
            {
                return false;
            }

            order.OrderDate = updatedOrder.OrderDate;
            order.UserId = updatedOrder.UserId;
            order.CarId = updatedOrder.CarId;

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Order> FindOrderById(int id)
        {
            var order = await this.dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            return order;
        }
    }
}
