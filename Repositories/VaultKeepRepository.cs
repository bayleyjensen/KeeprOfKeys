using System;
using System.Collections.Generic;
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
    internal VaultKeep Find(int keepId, int vaultId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (KeepId = @keepId AND VaultId = @vaultId)";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { keepId, vaultId });
    }

    internal VaultKeep GetById(int vaultId, int keepId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (VaultId = @vaultId and KeepId = @keepId);";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId });
    }

    internal VaultKeep Create(VaultKeep newData)
    {
      string sql = @"INSERT INTO vaultkeeps (keepId, vaultId, userId) VALUES (@KeepId, @VaultId, @UserId); SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      string sql =
       @"SELECT k.* FROM vaultkeeps vk
       INNER JOIN keeps k ON k.id = vk.keepId 
       WHERE (vaultId = @vaultId AND vk.userId = @userId);";
      return _db.Query<Keep>(sql, new { vaultId, userId });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id ";
      _db.Execute(sql, new { id });
    }
  }
}