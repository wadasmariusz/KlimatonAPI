using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ThreatMap.Admin.Controllers;

public class BaseController : Controller
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
    private IMapper _mapper;
    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    
    
}