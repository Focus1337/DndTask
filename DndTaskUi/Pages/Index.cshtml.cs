using DndTaskUi.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DndTaskUi.Pages;

public class IndexModel : PageModel
{
    public List<Character> Characters { get; set; } = null!;

    private static readonly HttpClient client = new();
    
    public void OnGet()
    {
        // сразу после открытия страницы идёт парсинг персов с бд
        var content = client.GetAsync("https://localhost:7049/GetAllCharacters").Result.Content;
        Characters = content.ReadFromJsonAsync<List<Character>>().Result!;
    }
}