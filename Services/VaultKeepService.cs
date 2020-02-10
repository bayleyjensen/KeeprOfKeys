using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository vrk)
    {
      _repo = vrk;
    }

    internal void Create(VaultKeep newData)
    {
      VaultKeep exists = _repo.Find(newData);
      if (exists != null) { throw new Exception("Keep already exists"); }
      _repo.Create(newData);
    }

    internal VaultKeep GetById(VaultKeep VaultId)
    {
      throw new NotImplementedException();
    }

    internal string Delete(VaultKeep vid)
    {
      VaultKeep exists = _repo.Find(vid);
      if (exists == null) { throw new Exception("INVALID ID COMBO"); }
      _repo.Delete(exists.Id);
      return "SHE GONE";
      {

      }
    }
  }
}