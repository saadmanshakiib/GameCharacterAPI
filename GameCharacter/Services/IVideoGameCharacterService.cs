using GameCharacter.DTOS;
using GameCharacter.Models;

namespace GameCharacter.Services;

public interface IVideoGameCharacterService
{
    Task<List<CharacterResponse>> getAllCharactersAsync();
    Task<CharacterResponse?> getCharacterByIdAsync(int id);
    Task<bool> addCharacterAsync(CreateGameReq character);
    Task<bool> deleteCharacterAsync(int id);
    Task<bool> updateCharacterAsync(int id, UpdateGameReq character);
}
