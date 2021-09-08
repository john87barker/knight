using System;
using System.Collections.Generic;
using knight.Models;
using knight.Services;
using Microsoft.AspNetCore.Mvc;

namespace knight.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CastlesController : ControllerBase
    {
    private readonly CastlesService _castlesService;
    public CastlesController(CastlesService castlesService)
    {
      _castlesService = castlesService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Castle>> Get()
    {
        try
        {
        IEnumerable<Castle> castles = _castlesService.Get();
        return Ok(castles);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Castle> Get(int id)
    {
        try
        {
        Castle castle = _castlesService.Get(id);
        return Ok(castle);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Castle> Create([FromBody] Castle newCastle)
    {
      Castle castle = _castlesService.Create(newCastle);
      return Ok(castle);
    }

    [HttpPut("{id}")]
    public ActionResult<Castle> Edit([FromBody] Castle updatedCastle, int id)
    {
        try
        {
        updatedCastle.Id = id;
        Castle castle = _castlesService.Edit(updatedCastle);
        return Ok(castle);
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
        try
        {
        _castlesService.Delete(id);
        return Ok("You have taken the castle!");
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    }
  }
}