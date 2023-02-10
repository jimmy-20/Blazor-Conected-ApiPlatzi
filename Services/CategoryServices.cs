using System.Text.Json;
using BlazorWebAssemblyApp.Models;

namespace BlazorWebAssemblyApp.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly HttpClient Client;
        private readonly JsonSerializerOptions OptionJson;

        public CategoryServices(HttpClient client){
            Client = client;
            OptionJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Category>> Get(){
            var response = await Client.GetAsync("categories");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<Category>>(content, OptionJson);
        }

    }

    public interface ICategoryService{
        Task<List<Category>> Get();
    }
}