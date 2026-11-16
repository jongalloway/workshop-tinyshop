using DataEntities;
using System.Net.Http.Json;

namespace Store.Services;

public class ProductService
{
    private readonly HttpClient httpClient;

    public ProductService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await httpClient.GetFromJsonAsync(
            "/api/Product",
            ProductSerializerContext.Default.ListProduct)
            ?? throw new InvalidOperationException("The products API returned an empty response.");
    }

    public async Task<Product> GetProduct(int id)
    {
        return await httpClient.GetFromJsonAsync(
            $"/api/Product/{id}",
            ProductSerializerContext.Default.Product)
            ?? throw new InvalidOperationException($"The products API returned no product for ID {id}.");
    }

    public async Task<Product> CreateProduct(Product product)
    {
        using var response = await httpClient.PostAsJsonAsync(
            "/api/Product",
            product,
            ProductSerializerContext.Default.Product);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync(ProductSerializerContext.Default.Product)
            ?? throw new InvalidOperationException("The products API returned an empty created product.");
    }

    public async Task UpdateProduct(Product product)
    {
        using var response = await httpClient.PutAsJsonAsync(
            $"/api/Product/{product.Id}",
            product,
            ProductSerializerContext.Default.Product);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteProduct(int id)
    {
        using var response = await httpClient.DeleteAsync($"/api/Product/{id}");
        response.EnsureSuccessStatusCode();
    }
}