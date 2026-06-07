using GameCharacter.Models;

namespace GameCharacter.Services;

public interface IVideoGameCharacterService
{
    Task<List<Character>> getAllCharactersAsync();
    Task<Character> getCharacterByIdAsync(int id);
    Task<Character> addCharacterAsync(Character character);
    Task<bool> deleteCharacterAsync(int id,Character character);
    Task<bool> updateCharacterAsync(int id);
}