using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ServingYouAdmin.Enums;

namespace ServingYouAdmin.Data
{
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly ServingYouContext context;        

        public SqlOrderRepository(ServingYouContext context)
        {
            this.context = context;            
        }

        public async Task AddAsync(Order order)
        {
            await context.Orders.AddAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(DateTime startDate, DateTime endDate)
        {
            return await context.Orders
                        .Include(o => o.Member)
                        .Where(o => o.OrderDate.Date >= startDate.Date && o.OrderDate.Date <= endDate.Date)
                        .OrderByDescending(o => o.OrderDate)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetNewOrdersAsync()
        {
            return await context.Orders
                        .Where(o => o.OrderDate.Date == DateTime.Now.Date)
                        .ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await context.Orders.FindAsync(id);
        }

        public async Task<Order> GetOrderDetailsAsync(int id)
        {
            var order = await context.Orders
                            .Include(o => o.OrderMenu)
                                .ThenInclude(m => m.Menu)
                            .Include(c => c.Member)
                            .Where(o => o.Id == id)
                            .FirstOrDefaultAsync();                        

            return order;
        }

        public void Remove(int id)
        {
            var order = context.Orders.FirstOrDefault(o => o.Id == id);

            if (order != null)            
                context.Orders.Remove(order);            
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(Order order)
        {
            order.OrderStatus = OrderStatus.Completed;
        }
    }
}
