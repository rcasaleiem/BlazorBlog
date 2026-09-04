using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using BlazorBlog.Services;


namespace BlazorBlog.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        public UserController(
           ILogger<UserController> logger,
           IMediator mediator,
           CrudHandler crudHandler,
           GatContext context)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.crudHandler = crudHandler;
            this.context = context;
        }

    }
}
