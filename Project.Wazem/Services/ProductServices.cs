using Project.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;

namespace Project.Wazem.Services
{
    public class ProductServices : IServices<Product>
    {
        private readonly HttpClient httpClient;

        public ProductServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task Delete(int id)
        {
            await httpClient.DeleteAsync("/api/Products"+ id);
        }

        public async Task<List<Product>> GetAll()
        {
            var ProductList = await httpClient.GetFromJsonAsync<List<Product>>("/api/Products");
                return ProductList;
        }

        public async Task<Product> GetByID(int id)
        {
            var Product = await httpClient.GetFromJsonAsync<Product>("/api/Products"+id);
                return Product;
        }

        public async Task Insert(Product item)
        {
          await  httpClient.PostAsJsonAsync<Product>("/api/Products", item);
        }

        public async Task Update(int id, Product item)
        {
            await httpClient.PutAsJsonAsync<Product>("/api/Products" + id, item);
        }
    }
}
