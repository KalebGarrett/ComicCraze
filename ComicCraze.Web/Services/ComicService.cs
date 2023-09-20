using ComicCraze.Models;
using System.Text.Json;


namespace ComicCraze.Web.Services;

public class ComicService
{
    public async Task<Comic> GetAll()
    {
        using var client = new HttpClient();
        var result = await client.GetAsync("https://xkcd.com/info.0.json");
        if (!result.IsSuccessStatusCode) return new Comic();
        var json = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Comic>(json);
    }
}