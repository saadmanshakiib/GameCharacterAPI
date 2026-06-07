using GameCharacter.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GameCharacter.Services;

public class VideoGameCharacterService : IVideoGameCharacterService
{
    static List<Character> characters = new List<Character>()
    {
        new Models.Character { id = 1, name = "Ghost", game = "Call of Duty", role = "Lieutanent" },
        new Models.Character { id = 2, name = "Price", game = "Call of Duty", role = "Captain" },
        new Models.Character { id = 3, name = "Messi", game = "Efootball", role = "Football Player" }
    };    
    public async Task<List<Character>> getAllCharactersAsync()
    {
        return await Task.FromResult(characters);
    }

    public Task<Character> addCharacterAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public Task<Character> getCharacterByIdAsync(int id)
    {
        var character = characters.Find(c => c.id == id);
        return Task.FromResult(character);
    }

    public Task<bool> updateCharacterAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> deleteCharacterAsync(int id, Character character)
    {
        throw new NotImplementedException();
    }
}