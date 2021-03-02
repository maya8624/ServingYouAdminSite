using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberAsync(int id);

        Task<IEnumerable<Member>> GetAllMembersAsync(DateTime startDate, DateTime endDate);

        Task<IEnumerable<Member>> GetNewMembersAsync();

        Task AddAsync(Member member);

        void Update(Member member);

        void Remove(Member member);
    }
}
