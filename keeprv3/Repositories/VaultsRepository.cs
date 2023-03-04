namespace keeprv3.Repositories;

public class VaultsRepository
{
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Vault Create(Vault vaultData)
    {
        string sql = @"
        INSERT INTO vaults
        (creatorId, name, description, img, isPrivate)
        VALUES
        (@creatorId, @name, @description, @img, @isPrivate);
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, vaultData);
        vaultData.Id = id;

        return vaultData;
    }

    internal Vault GetOneVault(int id)
    {
        string sql = @"
        SELECT
        vt.*,
        ac.*
        FROM vaults vt
        JOIN accounts ac ON ac.id = vt.creatorId
        WHERE vt.id = @id;
        ";

        return _db.Query<Vault, Account, Vault>(sql, (vault, account) =>
        {
            vault.Creator = account;
            return vault;
        }, new { id }).FirstOrDefault();

    }

    internal Vault Update(Vault vaultData)
    {

    }
}
