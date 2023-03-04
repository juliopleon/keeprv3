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

        return keep;
    }

    internal Keep GetOneKeep(int id, string userId)
    {
        Keep keep = _repo.GetOneKeep(id);
        if (keep == null)
        {
            throw new Exception($"No keep at Id:{id}");
        }

        if (keep.CreatorId != userId)
        {
            keep.Views++;
            UpdateKeep(keep);
        }

        return keep;

    }

    public void UpdateKeep(Keep k)
    {
        _repo.Update(k);
    }

    internal Keep Update(Keep keepUpdate, int id, string userId)
    {
        Keep original = GetOneKeep(id, userId);
        if (original.CreatorId != userId)
        {
            throw new Exception("not your keep to edit");
        }
        original.Name = keepUpdate.Name ?? original.Name;
        original.Description = keepUpdate.Description ?? original.Description;
        original.Img = keepUpdate.Img ?? original.Img;

        bool edited = _repo.Update(original);
        if (edited == false)
        {
            throw new Exception("your keep was not edited");
        }

        return original;
    }

    internal string Remove(int id, string userId)
    {
        Keep original = GetOneKeep(id, userId);
        if (original.CreatorId != userId)
        {
            throw new Exception("not your keep to delete!");
        }

        _repo.Remove(id);
        return $"{original.Name} has been deleted!";
    }
}
