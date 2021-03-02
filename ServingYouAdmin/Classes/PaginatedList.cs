using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServingYouAdmin.Classes
{
    public class PaginatedList<T> : List<T>
    {
        public int CurrentTotalPages { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int StartPage { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalDisplayPages { get; set; }

        //private readonly int DefaultDisplayNumbers = 10;

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            //TotalDisplayPages = (int)Math.Ceiling(TotalPages / (double)DefaultDisplayNumbers);
            
            //CurrentTotalPages = DefaultDisplayNumbers;
            //StartPage = 1;

            //if (pageIndex == CurrentTotalPages)
            //{
            //    CurrentTotalPages = CurrentTotalPages + DefaultDisplayNumbers;
            //    StartPage = pageIndex + 1;
            //}

            //if (CurrentTotalPages >= TotalPages) CurrentTotalPages = TotalPages;

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get => (PageIndex > 1);            
        }

        public bool HasNextPage
        {
            get => PageIndex < TotalPages;
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex)
        {
            int pageSize = 10;

            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
