using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knight.Models;

namespace knight.Repositories
{
    public class KnightsRepository
    {
    private readonly IDbConnection _db;
    public KnightsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Knight> Get()
    {
      string sql = "SELECT * FROM knights";
      return _db.Query<Knight>(sql).ToList();
    }
    internal Knight Get(int id)
    {
      string sql = "SELECT * FROM knights WHERE id = @id";
      return _db.QueryFirstOrDefault<Knight>(sql, new { id });
    }

    internal Knight Create(Knight newKnight)
    {
      string sql = @"
        INSERT INTO knights
        (name, mission)
        VALUES
        (@Name, @Mission);
        SELECT LAST_INSERT_ID();";
      newKnight.Id = _db.ExecuteScalar<int>(sql, newKnight);
      return newKnight;
    }

    internal Knight Update(Knight updatedKnight)
    {
      string sql = @"
        UPDATE knights
        SET
            name = @Name,
            mission = @Mission
        WHERE id = @Id;
        ";
      _db.Execute(sql, updatedKnight);
      return updatedKnight;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM knights WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

  }
}