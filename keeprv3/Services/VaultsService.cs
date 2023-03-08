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

    internal Vault Update1(Vault vaultUpdate)
    {
        Vault original = GetOneVault()
    }


}
