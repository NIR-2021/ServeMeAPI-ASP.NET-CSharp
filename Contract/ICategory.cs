using ServeMe_M2.Model;

namespace ServeMe_M2.Contract
{
    public interface ICategory
    {
        public Task<Category> GetCategory(string name);
    }
}
