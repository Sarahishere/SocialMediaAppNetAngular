
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Persistence;

namespace SocialMedia.Endpoint.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
 public class BaseController : ControllerBase
 {
    protected readonly DataContext? _context;
    public BaseController(DataContext context)
    {
        _context = context;
    }
 }
