namespace keeprv3.Services;

public class VaultsService
{
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
        _repo = repo;
    }

    internal Vault Create(Vault vaultData)
    {
        Vault vault = _repo.Create(vaultData);
        return vault;
    }

    internal Vault GetOneVault(int id, string userId)
    {
        Vault vault = _repo.GetOneVault(id);
        if (vault == null)
        {
            throw new Exception($"No Vault at ID:{id}");
        }
        if (vault.IsPrivate == true && vault.CreatorId != userId)
        {
            throw new Exception("This vault is Private!");
        }

        return vault;
    }

    internal Vault Update(Vault vaultUpdate)
    {
        Vault original = GetOneVault(vaultUpdate.Id, vaultUpdate.CreatorId);
        if (original.CreatorId != vaultUpdate.CreatorId) throw new Exception("Not your vault!");
        original.Name = vaultUpdate.Name ?? original.Name;
        original.Description = vaultUpdate.Description ?? original.Description;
        original.Img = vaultUpdate.Img ?? original.Img;
        original.IsPrivate = vaultUpdate.IsPrivate ?? original.IsPrivate;

        _repo.Update(original);
        return original;
    }


}
