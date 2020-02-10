using System;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }
    [HttpPost]
    [Authorize]
    public ActionResult<string> Create([FromBody] VaultKeep newData)
    {
      try
      {
        _vks.Create(newData);
        return Ok("Success");
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    [Authorize]

    public ActionResult<VaultKeep> Get(int id)
    {
      try
      {
        return Ok(_vks.GetById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpPut("/{id}/keeps")]
    [Authorize]
    public ActionResult<string> Edit([FromBody] VaultKeep vid)
    {
      try
      {
        return Ok(_vks.Delete(vid));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}