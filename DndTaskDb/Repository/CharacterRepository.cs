using DndTaskDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DndTaskDb.Repository;

public class CharacterRepository
{
    private readonly ApplicationContext _context;

    public CharacterRepository(ApplicationContext context) =>
        _context = context;

    public record CharacterIdNameModel(int Id, string Name);

    public IQueryable<CharacterIdNameModel> GetAllCharacterNamesAndId() =>
        _context.Characters.Select(c => new CharacterIdNameModel(c.Id, c.Name));

    public async Task<Character?> GetCharacterAsync(int id) =>
        await _context.Characters.FirstAsync(c => c.Id == id);

    public async Task AddAsync(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Character character)
    {
        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Character character)
    {
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
    }
}