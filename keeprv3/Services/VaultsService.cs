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
}
