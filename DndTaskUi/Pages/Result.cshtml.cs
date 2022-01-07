using DndTaskUi.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DndTaskUi.Pages;

public class Result : PageModel
{
    public CalculatedCharacterModel Character { get; set; }

    private static readonly HttpClient client = new();

    private record CharacterModel(
        string Name,
        int AttackModifier,
        int AttackPerRound,
        int DamageDicesCount,
        int DamageDiceType,
        int WeaponModifier,
        int AttackModifierAddition,
        int DamageModifierAddition);


    public record CalculatedCharacterModel(
        string Name,
        int AttackModifier,
        int AttackPerRound,
        int DamageDicesCount,
        int DamageDiceType,
        int WeaponModifier,
        int MinAcToAlwaysHit,
        int DamagePerRoundLeft,
        int DamagePerRoundRight);

    public void OnGet()
    {
        var id = Request.Query["id"];
        var attack = int.Parse(Request.Query["attack"]);
        var weapon = int.Parse(Request.Query["weapon"]);
        var content = client.GetAsync($"https://localhost:7049/GetCharacterById?id={id}").Result.Content;
        Console.WriteLine(content.ReadAsStringAsync().Result);
        var character = content.ReadFromJsonAsync<Character>().Result!;
        var characterModel = new CharacterModel(
            Name: character.Name,
            AttackModifier: character.AttackModifier,
            AttackPerRound: character.AttackPerRound,
            DamageDicesCount: character.DamageDicesCount,
            DamageDiceType: character.DamageDiceType,
            WeaponModifier: character.WeaponModifier,
            AttackModifierAddition: attack,
            DamageModifierAddition: weapon);
        content = client
            .PostAsync($"https://localhost:7198/CalculateCharacterProperties", JsonContent.Create(characterModel))
            .Result.Content;
        Console.WriteLine(content.ReadAsStringAsync().Result);
        Character = content.ReadFromJsonAsync<CalculatedCharacterModel>().Result!;
    }
}

// public class Result : PageModel
// {
//     public Character Character { get; set; } = null!;
//
//     private static readonly HttpClient client = new();
//     
//     public void OnGet()
//     {
//         var id = Request.Query["id"];
//         var attack = int.Parse(Request.Query["attack"]);
//         var weapon = int.Parse(Request.Query["weapon"]);
//         var content = client.GetAsync($"https://localhost:7049/GetCharacterById?id={id}").Result.Content;
//         
//         Console.WriteLine(content.ReadAsStringAsync().Result);
//         
//         var character = content.ReadFromJsonAsync<Character>().Result!;
//         var characterModel = new CharacterModel(
//             Name: character.Name,
//             AttackModifier: character.AttackModifier,
//             AttackPerRound: character.AttackPerRound,
//             DamageDicesCount: character.DamageDicesCount,
//             DamageDiceType: character.DamageDiceType,
//             WeaponModifier: character.WeaponModifier,
//             AttackModifierAddition: attack,
//             DamageModifierAddition: weapon);
//        
//         content = client
//             .PostAsync($"https://localhost:7198/CalculateCharacterProperties", JsonContent.Create(characterModel))
//             .Result.Content;
//         
//         Console.WriteLine(content.ReadAsStringAsync().Result);
//         Character = content.ReadFromJsonAsync<CalculatedCharacterModel>().Result!;
//     }
// }