namespace keeprv3.Repositories;

public class KeepsRepository
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Keep Create(Keep keepData)
    {
        string sql = @"
        INSERT INTO keeps
        (name, description, img, creatorId)
        VALUES
        (@name, @description, @img, @creatorId);
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, keepData);
        keepData.Id = id;
        return keepData;
    }

    public List<Keep> Get()
    {
        string sql = @"
        SELECT
        kp.*,
        ac.*
        FROM keeps kp
        JOIN accounts on ac ON ac.id = kp.creatorId;
        ";
        List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
        {
            keep.Creator = account;
            return keep;
        }).ToList();

        return keeps;
    }

    internal Keep GetOneKeep(int id)
    {
        string sql = @"
        SELECT
        kp.*,
        ac.*
        FROM keeps kp
        JOIN accounts ac ON ac.id = kp.creatorId
        WHERE kp.id = @id;
        ";

        return _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
        {
            keep.Creator = account;
            return keep;
        }, new { id }).FirstOrDefault();

    }


    internal bool Update(Keep original)
    {
        string sql = @"
        UPDATE keeps
        SET
        name = @name,
        description = @description,
        img = @img,
        views = @views,
        kept = @kept
        WHERE id = @id;
        ";
        int rows = _db.Execute(sql, original);
        return rows > 0;
    }

    internal bool Remove(int id)
    {
        string sql = @"
        DELETE FROM keeps
        WHERE id = @id;
        ";
        int rows = _db.Execute(sql, new { id });
        return rows > 0;
    }
}
