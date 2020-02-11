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
    internal string Delete(int vaultId, int keepId, string userId)
    {
      VaultKeep exists = _repo.Find(vaultId, keepId, userId);
      if (exists == null) { throw new Exception("INVALID ID COMBO"); }
      else if (exists.UserId != userId) { throw new Exception("THIS AINT YOUR FOOL!"); }
      _repo.Delete(exists.VaultId, exists.KeepId, exists.UserId);
      return "SHE GONE";
    }

    internal object GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }

    internal string Create(VaultKeep newData)
    {
      VaultKeep exists = _repo.Find(newData);
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