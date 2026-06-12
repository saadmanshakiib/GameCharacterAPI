using GameCharacter.Data;
using GameCharacter.DTOS;
using GameCharacter.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GameCharacter.Services;

public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
{

    public async Task<List<CharacterResponse>> getAllCharactersAsync() =>
        await context.characters.Select(c => new CharacterResponse()
        {
            name = c.name,
            game = c.game,
            role = c.role
        }).ToListAsync();
    

    public async Task<bool> addCharacterAsync(CreateGameReq character)
    {
        var newCharacter = new Character()
        {
            name = character.name,
            game = character.game,
            role = character.role
        };
        context.characters.Add(newCharacter);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<CharacterResponse?> getCharacterByIdAsync(int id)
    {
        var r = await context.characters.Where(c => c.id == id).Select(c => new CharacterResponse()
        {
            name = c.name,
            game = c.game,
            role = c.role
        }).FirstOrDefaultAsync();
        return r;
    }

    public async Task<bool> updateCharacterAsync(int id, UpdateGameReq character)
    {
        var existingCharacter = await context.characters.FindAsync(id);

        if (existingCharacter is null)
        {
            return false;
        }

        existingCharacter.name = character.name;
        existingCharacter.game = character.game;
        existingCharacter.role = character.role;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> deleteCharacterAsync(int id)
    {
        var character = await context.characters.FindAsync(id);

        if (character is null)
        {
            return false;
        }

        context.characters.Remove(character);
        await context.SaveChangesAsync();
        return true;
    }
}
