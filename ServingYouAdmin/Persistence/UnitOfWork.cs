using ServingYouAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServingYouContext context;

        public UnitOfWork(ServingYouContext context)
        {
            this.context = context;            
        }
                
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
