using System;
using System.Collections.Generic;
using knight.Models;
using knight.Services;
using Microsoft.AspNetCore.Mvc;

namespace knight.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
        public class KnightsController : ControllerBase
    {
    private readonly KnightsService _knightsService;
    public KnightsController(KnightsService knightsService)
    {
      _knightsService = knightsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Knight>> Get()
    {
        try
        {
        IEnumerable<Knight> knights = _knightsService.Get();
        return Ok(knights);
      }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Knight> Get(int id)
    {
        try
        {
            Knight knight = _knightsService.Get(id);
            return Ok(knight);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPost]
    public ActionResult<Knight> Create([FromBody] Knight newKnight)
    {
        try
        {
            Knight knight = _knightsService.Create(newKnight);
            return Ok(knight);
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Knight> Edit([FromBody] Knight updatedKnight, int id)
    {
        try
        {
            updatedKnight.Id = id;
            Knight knight = _knightsService.Edit(updatedKnight);
            return Ok(knight);
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
        _knightsService.Delete(id);
        return Ok("This Knight no longer exists! Murder!!!");
      }
        catch (Exception err)
        {
        return BadRequest(err.Message);
      }
    } 



  }
}