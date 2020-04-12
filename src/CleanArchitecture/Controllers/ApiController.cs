namespace CleanArchitecture.WebAPI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        public ApiController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        protected IMediator Mediator { get; }
    }
}
