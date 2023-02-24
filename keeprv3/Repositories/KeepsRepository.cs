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
        ac.
        FROM keeps kp
        JOIN accounts on ac ON ac.id = kp.creatorId;
        ";
        List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
        {
            keep.Creator = account;
            return keep;
        }).ToList();
    }
}
