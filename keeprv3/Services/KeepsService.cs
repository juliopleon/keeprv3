namespace keeprv3.Services;

public class KeepsService
{
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
        _repo = repo;
    }

    internal Keep Create(Keep keepData)
    {
        Keep keep = _repo.Create(keepData);
        return keep;

    }

    internal List<Keep> Get(string userId)
    {
        List<Keep> keeps = _repo.Get();
        List<Keep> filtered = keeps.FindAll(k => k.CreatorId == userId);

        return keeps;
    }
}
