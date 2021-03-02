using ServingYouAdmin.Classes;
using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public interface IMenuRepository
    {
        Task<Menu> GetMenuAsync(int id);        

        Task<PaginatedList<Menu>> GetAllMenusAsync(string strOrder, string searchString, string category, int? pageNumber);

        Task<IEnumerable<Menu>> GetNewMenusAsync();

        Task<IEnumerable<Menu>> GetByNameAsync(string name);

        Task AddSync(Menu menu);

        void Update(Menu menu);

        void Remove(Menu menu); 
    }
}
