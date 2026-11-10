using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using BlazorBlog.Services;
using BlazorBlog.Models.Tables;
using BlazorBlog.Models.Dtos;


namespace BlazorBlog.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly CrudHandler _crudhandler;
        private readonly BlogDBContext _dbContext;

        public UserController(
           ILogger<UserController> logger,
           IMediator mediator,
           CrudHandler crudHandler,
           BlogDBContext context)
        {
            this._mediator = mediator;
            this._logger = logger;
            this._crudhandler = crudHandler;
            this._dbContext = context;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [HttpPost("NewUserInsert")]
        public async Task<IActionResult> InsertUser([FromBody] NewUserInsertDto data)
        {
            try
            {
                var result = await _crudhandler.Insert<UserDto, NewUserInsertDto, UsersTable>(data);
                _logger.LogInformation($"Insert new user got success");
                return Ok(result);
            }
            catch (Exception ex)
            {
                string message = $"Error during user insert";
                _logger.LogError(message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
