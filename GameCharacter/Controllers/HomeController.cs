using System.Diagnostics;
using GameCharacter.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GameCharacter.Models;
using GameCharacter.Services;

namespace GameCharacter.Controllers;

[Route("characters")]
[ApiController]

public class HomeController(IVideoGameCharacterService service) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<CharacterResponse>>> getAllCharacters()
    {
       return await service.getAllCharactersAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterResponse>> getCharacterByIdAsync(int id)
    {
       var character =  await service.getCharacterByIdAsync(id);
       return character is null ? NotFound("No Character with this id") : Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> createGame(CreateGameReq newgame)
    {
        var createdCharacter = await service.addCharacterAsync(newgame);
        return createdCharacter;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> updateCharacterAsync(int id, UpdateGameReq character)
    {
        var updatedCharacter = await service.updateCharacterAsync(id, character);
        return updatedCharacter ? NoContent() : NotFound("No Character with this id");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteCharacterAsync(int id)
    {
        var deletedCharacter = await service.deleteCharacterAsync(id);
        return deletedCharacter ? NoContent() : NotFound("No Character with this id");
    }

}
