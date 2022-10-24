using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Endpoints
{
    [Authorize]
    [ApiController]
    public abstract class BaseEndpoint : ControllerBase
    {
    }
}