using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository vr)
    {
      _repo = vr;
    }

    internal object Get()
    {
      return _repo.Get();
    }

    internal Vault GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("INVALID ID"); }
      return exists;
    }

    internal Vault Create(Vault newData)
    {
      _repo.Create(newData);
      return newData;
    }

    internal Vault Edit(Vault update)
    {
      var exists = _repo.GetById(update.Id);
      if (exists == null) { throw new Exception("INVALID ID"); }
      _repo.Edit(update);
      return update;
      {

      }

    }

    internal string Delete(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("INVALID ID"); }
      _repo.Delete(id);
      return "successfully Deleted";
    }
  }
}