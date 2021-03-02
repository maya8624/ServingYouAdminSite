using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServingYouAdmin.Models;

namespace ServingYouAdmin.Data
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(int id);

        Task<IEnumerable<Order>> GetAllOrdersAsync(DateTime startDate, DateTime endDate);

        Task<Order> GetOrderDetailsAsync(int id);

        Task<IEnumerable<Order>> GetNewOrdersAsync();

        Task AddAsync(Order order);

        void Update(Order order);

        void UpdateStatus(Order order);

        void Remove(int id);
    }
}
