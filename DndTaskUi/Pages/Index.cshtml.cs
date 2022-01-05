using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DndTaskUi.Pages;

public class IndexModel : PageModel
{
    public List<CharacterIdNameModel> Characters { get; set; }

    private readonly ILogger<IndexModel> _logger;
    private static readonly HttpClient _client = new();

    public IndexModel(ILogger<IndexModel> logger) => 
        _logger = logger;

    public record CharacterIdNameModel(int Id, string Name);
    public void OnGet()
    {
        var content = _client.GetAsync("https://localhost:7049/GetAllCharacterNamesAndId").Result.Content;
        var t = content.ReadFromJsonAsync<List<CharacterIdNameModel>>().Result;
        Characters = t;
    }
}