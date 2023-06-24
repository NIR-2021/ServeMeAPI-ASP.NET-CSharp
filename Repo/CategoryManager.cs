using Microsoft.EntityFrameworkCore;
using ServeMe_M2.Contract;
using ServeMe_M2.Data;
using ServeMe_M2.Model;

namespace ServeMe_M2.Repo
{
    public class CategoryManager : ICategory
    {
        private readonly ServeMeDbContext serveme;

        public CategoryManager(ServeMeDbContext serveme)
        {
            this.serveme = serveme;
        }

        public async Task<Category> GetCategory(string name)
        {
            return await serveme.categories.Where(b => b.Name == name).FirstOrDefaultAsync();
        }
    }
}
