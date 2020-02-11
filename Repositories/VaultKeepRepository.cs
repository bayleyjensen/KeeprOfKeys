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

    internal VaultKeep Find(int keepId, int vaultId, string userId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (keepId = @keepId AND VaultId = @vaultId)";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId, userId });
    }
    internal VaultKeep Find(VaultKeep newData)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (VaultId = @vaultId AND keepId = @keepId AND userId = @UserId)";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, newData);
    }

    internal VaultKeep Create(VaultKeep newData)
    {
      string sql = @"INSERT INTO vaultkeeps (keepId, vaultId, userId) VALUES (@KeepId, @VaultId, @UserId); SELECT_LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }

    internal object GetKeepsByVaultId(int id)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int VaultId, int KeepId, string UserId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id ";
      _db.Execute(sql, new { VaultId, KeepId, UserId });
    }
  }
}