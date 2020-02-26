using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal Keep GetById(int Id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { Id });
    }

    internal void Edit(Keep update)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name, views = @Views
      WHERE id = @Id;
      ";
      _db.Execute(sql, update);
    }

    internal Keep Create(Keep newKeep)
    {
      string sql = @"INSERT INTO keeps (name, description, img, userId, isPrivate) Value (@Name, @Description, @Img, @userId, @isPrivate);
        SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newKeep);
      newKeep.Id = id;
      return newKeep;

    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Keep> GetUserKeeps(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE UserId = @userId;";
      return _db.Query<Keep>(sql, new { userId });
    }
  }
}