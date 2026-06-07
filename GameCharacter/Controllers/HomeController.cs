using System.Diagnostics;
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
    public async Task<ActionResult<List<Character>>> getAllCharacters() =>
        await service.getAllCharactersAsync();
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> getCharacterByIdAsync(int id)=>
        await service.getCharacterByIdAsync(id);
    
}