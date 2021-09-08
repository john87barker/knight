using System;
using System.Collections.Generic;
using knight.Models;
using knight.Repositories;

namespace knight.Services
{
  public class KnightsService
  {
    //   TODO add KNight repo here
    private readonly KnightsRepository _repo;
    public KnightsService(KnightsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Knight> Get()
    {
      return _repo.Get();
    }
    internal Knight Get(int id)
    {
      Knight knight = _repo.Get(id);
      if (knight == null)
      {
        throw new Exception("invalid id");
      }
      return knight;
    }

    internal Knight Create(Knight newKnight)
    {
      Knight knight = _repo.Create(newKnight);
      if(knight == null)
      {
        throw new Exception("invalid Id");
      }
      return knight;
    }

    internal Knight Edit(Knight updatedKnight)
    {
      Knight original = Get(updatedKnight.Id);
      updatedKnight.Name = updatedKnight.Name != null ? updatedKnight.Name : original.Name;
      updatedKnight.Mission = updatedKnight.Mission != null ? updatedKnight.Mission : original.Mission;

      return _repo.Update(updatedKnight);
    }

    internal void Delete(int id)
    {
      Knight original = Get(id);
      _repo.Delete(id);
    }
  }
}