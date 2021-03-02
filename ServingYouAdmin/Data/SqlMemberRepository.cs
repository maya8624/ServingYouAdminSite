using Microsoft.EntityFrameworkCore;
using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public class SqlMemberRepository : IMemberRepository
    {
        private readonly ServingYouContext context;

        public SqlMemberRepository(ServingYouContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Member member)
        {
            await context.Members.AddAsync(member);             
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync(DateTime startDate, DateTime endDate)
        {
            return await context.Members
                        .Where(m => m.DateRegistered.Date >= startDate.Date && m.DateRegistered.Date <= endDate)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Member>> GetNewMembersAsync()
        {
            return await context.Members
                        .Where(m => m.DateRegistered.Date == DateTime.Now.Date)
                        .ToListAsync();
        }

        public async Task<Member> GetMemberAsync(int id)
        {
            return await context.Members.FindAsync(id);
        }

        public void Remove(Member member)
        {
            context.Members.Remove(member);
        }

        public void Update(Member memberChanges)
        {
            var member = context.Members.Attach(memberChanges);            
            member.State = EntityState.Modified;
        }
    }
}
