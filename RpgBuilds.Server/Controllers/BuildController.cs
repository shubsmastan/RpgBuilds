using Microsoft.AspNetCore.Mvc;
using RpgBuilds.Server.Models;
using RpgBuilds.Server.Services;

namespace RpgBuilds.Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BuildController : ControllerBase
{
    private readonly BuildService _buildService;

    public BuildController(BuildService buildService) =>
        _buildService = buildService;

    // GET

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var builds = await _buildService.GetBuilds();

        if (builds.Count == 0) return NotFound();

        return Ok(builds);
    }

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> Get(string id)
    {
        var build = await _buildService.GetBuild(id);

        if (build is null) return NotFound();

        return Ok(build);
    }

    //POST

    [HttpPost]
    public async Task<IActionResult> Post(Build build)
    {
        await _buildService.CreateBuild(build);
        return CreatedAtAction(nameof(Get), new { id = build.Id }, build);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, Build updatedBuild)
    {
        var build = await _buildService.GetBuild(id);

        if (build is null) return BadRequest();

        build.Name = updatedBuild.Name;
        build.CharacterName = updatedBuild.CharacterName;
        build.CharacterClass = updatedBuild.CharacterClass;

        await _buildService.UpdateBuild(build);

        return Ok(build);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var build = await _buildService.GetBuild(id);

        if (build is null) return BadRequest();

        await _buildService.DeleteBuild(id);

        return Ok();
    }
}