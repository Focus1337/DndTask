using DndTaskDb.Models;
using DndTaskDb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DndTaskDb.Controllers;

[ApiController]
[Route("[action]")]
public class CharacterController : ControllerBase
{
    private readonly CharacterRepository _repository;
    
    public CharacterController(CharacterRepository repository) =>
        _repository = repository;

    [HttpGet]
    public IActionResult GetAllCharacterNamesAndId() =>
        new JsonResult(_repository.GetAllCharacterNamesAndId());

    [HttpGet]
    public async Task<IActionResult> GetCharacterById([FromQuery] int id) =>
        new JsonResult(await _repository.GetCharacterAsync(id));

    public record CharacterAddingModel(
        string Name,
        int AttackModifier,
        int AttackPerRound,
        int DamageDicesCount,
        int DamageDiceType,
        int WeaponModifier);

    [HttpPost]
    public async Task<IActionResult> AddCharacter([FromBody] CharacterAddingModel characterAddingModel)
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

        await _repository.AddAsync(character);
        return Ok();
    }
    
    // [HttpPost]
    // public async Task<IActionResult> RemoveCharacter([FromBody] CharacterAddingModel characterAddingModel)
    // {
    //     var character = new Character
    //     {
    //         Name = characterAddingModel.Name,
    //         AttackModifier = characterAddingModel.AttackModifier,
    //         AttackPerRound = characterAddingModel.AttackPerRound,
    //         DamageDicesCount = characterAddingModel.DamageDicesCount,
    //         DamageDiceType = characterAddingModel.DamageDiceType,
    //         WeaponModifier = characterAddingModel.WeaponModifier
    //     };
    //
    //     await _repository.RemoveAsync(character);
    //     return Ok();
    // }
    //
    // [HttpPost]
    // public async Task<IActionResult> UpdateCharacter([FromBody] CharacterAddingModel characterAddingModel)
    // {
    //     var character = new Character
    //     {
    //         Name = characterAddingModel.Name,
    //         AttackModifier = characterAddingModel.AttackModifier,
    //         AttackPerRound = characterAddingModel.AttackPerRound,
    //         DamageDicesCount = characterAddingModel.DamageDicesCount,
    //         DamageDiceType = characterAddingModel.DamageDiceType,
    //         WeaponModifier = characterAddingModel.WeaponModifier
    //     };
    //
    //     await _repository.UpdateAsync(character);
    //     return Ok();
    // }
}