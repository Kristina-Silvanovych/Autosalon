using autosalon.Models;

namespace autosalon.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> CreateOrder(Order order);
        Task<bool> DeleteOrder(int id);
        Task<bool> ChangeOrder(int id, Order updatedOrder);

        Task<Order> FindOrderById(int id);
    }
}
