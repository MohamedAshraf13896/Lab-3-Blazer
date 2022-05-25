
using Project.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Project.Wazem.Services
{
    public class CategoryServices: IServices<Category>
    {
        private readonly HttpClient httpClient;

        public CategoryServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task Delete(int id)
        {
            await httpClient.DeleteAsync("/api/Categories"+ id);
        }

        public async Task<List<Category>> GetAll()
        {
            var CategoryList = await httpClient.GetFromJsonAsync<List<Category>>("/api/Categories");
            return CategoryList;
        }

        public async Task<Category> GetByID(int id)
        {
            var category = await httpClient.GetFromJsonAsync<Category>("/api/Categories" + id);
            return category;
        }

        public async Task Insert(Category item)
        {
            await httpClient.PostAsJsonAsync<Category>("/api/Categories", item);
        }

        public async Task Update(int id, Category item)
        {
            await httpClient.PutAsJsonAsync<Category>("/api/Categories" + id, item);
        }
    }
}
