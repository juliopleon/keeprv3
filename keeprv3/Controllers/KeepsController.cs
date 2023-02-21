namespace keeprv3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
    private readonly KeepsService _keepsService;
    private readonly Auth0Provider _auth0Provider;

    public KeepsController(KeepsService keepsService, Auth0Provider auth0Provider)
    {
        _keepsService = keepsService;
        _auth0Provider = auth0Provider;
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            keepData.CreatorId = userInfo.Id;

            Keep keep = _keepsService.Create(keepData);
            keep.Creator = userInfo;

            return Ok(keep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
