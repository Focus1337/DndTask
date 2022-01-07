using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DndTaskUi.Pages;

public class IndexModel : PageModel
{
    public List<CharacterIdNameModel> Characters { get; set; } = null!;

    private static readonly HttpClient _client = new();
    
    public record CharacterIdNameModel(int Id, string Name);

    public void OnGet()
    {
        // сразу после открытия страницы идёт парсинг характеров с бд
        var content = _client.GetAsync("https://localhost:7049/GetAllCharacterNamesAndId").Result.Content;
        var t = content.ReadFromJsonAsync<List<CharacterIdNameModel>>().Result;
        
        if (t != null) 
            Characters = t;
    }
}