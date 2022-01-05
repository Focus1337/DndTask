using DndTaskDb.Db;
using DndTaskDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DndTaskDb.Controllers;

[ApiController]
[Route("[action]")]
public class DefaultController : ControllerBase
{
    private record CharacterIdNameModel(int Id, string Name);
    
    [HttpGet]
    public IActionResult GetAllCharacterNamesAndId([FromServices] AppDataContext dataContext) =>
        new JsonResult(dataContext.Characters.Select(c => new CharacterIdNameModel(c.Id, c.Name)));

    [HttpGet]
    public IActionResult GetCharacterById([FromQuery]int id, [FromServices] AppDataContext dataContext) => 
        new JsonResult(dataContext.Characters.First(c => c.Id == id));

    public record CharacterAddingModel(
        string Name,
        int AttackModifier,
        int AttackPerRound,
        int DamageDicesCount,
        int DamageDiceType,
        int WeaponModifier);

    [HttpPost]
    public IActionResult AddCharacter(
        [FromBody] CharacterAddingModel characterAddingModel,
        [FromServices] AppDataContext dataContext)
    {
        var character = new Character
        {
            Name = characterAddingModel.Name,
            AttackModifier = characterAddingModel.AttackModifier,
            AttackPerRound = characterAddingModel.AttackPerRound,
            DamageDicesCount = characterAddingModel.DamageDicesCount,
            DamageDiceType = characterAddingModel.DamageDiceType,
            WeaponModifier = characterAddingModel.WeaponModifier
        };
        dataContext.Characters.Add(character);
        dataContext.SaveChanges();
        return Ok();
    }
}