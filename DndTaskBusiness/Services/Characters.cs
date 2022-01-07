namespace DndTaskBusiness.Services;

// public record CharacterModel(
//     string Name,
//     int AttackModifier,
//     int AttackPerRound,
//     int DamageDicesCount,
//     int DamageDiceType,
//     int WeaponModifier,
//     int AttackModifierAddition,
//     int DamageModifierAddition);
//
// public record CalculatedCharacterModel(
//     string Name,
//     int AttackModifier,
//     int AttackPerRound,
//     int DamageDicesCount,
//     int DamageDiceType,
//     int WeaponModifier,
//     int MinAcToAlwaysHit,
//     int DamagePerRoundLeft,
//     int DamagePerRoundRight);

public class CharacterBase
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int AttackModifier { get; set; }
    public int AttackPerRound { get; set; }
    public int DamageDicesCount { get; set; }
    public int DamageDiceType { get; set; }
    public int WeaponModifier { get; set; }   
}

public class CharacterModel : CharacterBase
{
    public int AttackModifierAddition { get; set; }
    public int DamageModifierAddition { get; set; }
}

public class CalculatedCharacterModel : CharacterBase
{
    public int MinAcToAlwaysHit { get; set; }
    public int DamagePerRoundLeft { get; set; }
    public int DamagePerRoundRight { get; set; }
}