using Microsoft.EntityFrameworkCore;
using ServingYouAdmin.Classes;
using ServingYouAdmin.Enums;
using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public class SqlMenuRepository : IMenuRepository
    {
        private readonly ServingYouContext context;

        public SqlMenuRepository(ServingYouContext context)
        {
            this.context = context;
        }

        public async Task AddSync(Menu menu)
        {
           await context.Menus.AddAsync(menu);
        }
               
        public async Task<Menu> GetMenuAsync(int id)
        {
            return await context.Menus.FindAsync(id);
        }

        public async Task<PaginatedList<Menu>> GetAllMenusAsync(string sortOrder, string searchString, string category, int? pageNumber)
        {
            var menus = from m in context.Menus
                        select m;

            //var menus2 = context.Menus.AsQueryable();                     
            
            if (!string.IsNullOrEmpty(searchString))            
                menus = menus.Where(m => m.Name.Contains(searchString));

            if (!string.IsNullOrEmpty(category))
            {
                menus = menus.Where(m => m.Category == (MenuCategory)Enum.Parse(typeof(MenuCategory), category));
            }
            
            switch (sortOrder)
            {
                case "name_desc":
                    menus = menus.OrderByDescending(m => m.Name);
                    break;           
                default:
                    menus = menus.OrderByDescending(m => m.DateCreated);
                    break;
            }
                        
            return await PaginatedList<Menu>.CreateAsync(menus.AsNoTracking(), pageNumber ?? 1);            
        }

        public async Task<IEnumerable<Menu>> GetNewMenusAsync()
        {
            return await context.Menus
                        .Where(m => m.DateCreated.Date == DateTime.Now.Date)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Menu>> GetByNameAsync(string name)
        {
            return await context.Menus.ToListAsync();
        }

        public void Remove(Menu menu)
        {            
            context.Menus.Remove(menu);            
        }

        public void Update(Menu menuChanges)
        {
            var menu = context.Menus.Attach(menuChanges);
            menu.State = EntityState.Modified;           
        }

        public bool MenuExist(int id) 
        {
            return context.Menus.Any(m => m.Id == id);
        }
    }
}
