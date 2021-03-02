using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public interface IBookingRepository
    {
        Task<Booking> GetBooking(int id);

        Task<IEnumerable<Booking>> GetBookingsAsync(DateTime startDate, DateTime endDate);

        Task AddAsync(Booking booking);

        void Update(Booking booking);

        void Remove(int id);
    }
}
