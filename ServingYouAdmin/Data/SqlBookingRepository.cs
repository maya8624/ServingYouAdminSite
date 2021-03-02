using Microsoft.EntityFrameworkCore;
using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public class SqlBookingRepository : IBookingRepository
    {
        private readonly ServingYouContext context;

        public SqlBookingRepository(ServingYouContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Booking booking)
        {
            await context.Bookings.AddAsync(booking);
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync(DateTime startDate, DateTime endDate)
        {
            return await context.Bookings
                        .Where(b => b.DateCreated.Date >= startDate.Date && b.DateCreated.Date <= endDate.Date)
                        .OrderBy(b => b.DateBooked)
                        .ToListAsync();
        }

        public async Task<Booking> GetBooking(int id)
        {
            return await context.Bookings.FindAsync(id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Booking bookingChanges)
        {
            var booking = context.Bookings.Attach(bookingChanges);
            booking.State = EntityState.Modified;           
        }
    }
}
