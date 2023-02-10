using System.Net.Http.Json;
using System.Text.Json;
using BlazorWebAssemblyApp.Models;

namespace BlazorWebAssemblyApp.Services;

class ProductService : IProductService
{
    private readonly HttpClient Client;
    private readonly JsonSerializerOptions OptionJson;

    public ProductService(HttpClient httpClient)
    {
        Client = httpClient;
        OptionJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<Product>>? Get()
    {
        var response = await Client.GetAsync("products");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }

        return JsonSerializer.Deserialize<List<Product>>(content, OptionJson);
    }

    public async Task Post(Product p)
    {
        var response = await Client.PostAsync("products", JsonContent.Create(p));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
    }

    public async Task Delete(int id)
    {
        var response = await Client.DeleteAsync($"products/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
    }
}

public interface IProductService
{
    Task<List<Product>>? Get();
    Task Post(Product p);
    Task Delete(int id);
}