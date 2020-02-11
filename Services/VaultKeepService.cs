using System;
using System.Collections.Generic;
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
    public string Delete(int vaultId, int keepId, string userId)
    {
      var exists = _repo.GetById(vaultId, keepId);
      if (exists == null) { throw new Exception("INVALID ID COMBO"); }
      else if (exists.UserId != userId) { throw new Exception("THIS AINT YOURS FOOL!"); }
      _repo.Delete(exists.Id);
      return "SHE GONE";
    }
    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      var exists = _repo.GetKeepsByVaultId(vaultId, userId);
      if (exists == null) { throw new Exception("THAT ID DOESNT EXIST"); }
      return exists;
    }
    internal string Create(VaultKeep newData)
    {
      VaultKeep exists = _repo.Find(newData.KeepId, newData.VaultId);
      if (exists == null)
      {
        _repo.Create(newData);
      }
      else if (exists != null)
      {
        return "THIS HAS ALREADY BEEN CREATED";
      }
      return "successfuly created";
    }
  }
}