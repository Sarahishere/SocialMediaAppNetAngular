
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Persistence.Interfaces;

namespace SocialMedia.Endpoint.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
 public class BaseController : ControllerBase
 {
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;
    public BaseController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
 }
