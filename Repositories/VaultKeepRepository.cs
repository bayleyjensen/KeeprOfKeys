using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Find(VaultKeep vk)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (keepId = @keepId AND VaultId = @vaultId)";
      return _db.QueryFirstOrDefault(sql, vk);
    }

    internal VaultKeep Create(VaultKeep newData)
    {
      string sql = "INSERT INTO vaultkeeps (keepId, vaultId) VALUES (@KeepId, @VaultId); SELECT_LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newData);
      return newData;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}