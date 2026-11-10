using BlazorBlog.Models.Dtos;
using BlazorBlog.Models.Tables;
using BlazorBlog.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BlazorBlog.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IMediator _mediator;
        private readonly CrudHandler _crudhandler;
        private readonly BlogDBContext _dbContext;

        public PostController(
            ILogger<PostController> logger,
            IMediator mediator,
            CrudHandler crudHandler,
            BlogDBContext context)
        {
            this._logger = logger;
            this._mediator = mediator;
            this._crudhandler = crudHandler;
            this._dbContext = context;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
        {
            try
            {
                var result = await _crudhandler.Get<PostDto, PostsTable>(id);
                _logger.LogInformation($"Post request using id {id}");
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                string message = $"No posts with id {id}";
                _logger.LogWarning(message);
                return NotFound(message);
            }
            catch (Exception ex)
            {
                string message = $"Error during post request with id {id}";
                _logger.LogError(ex, message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [HttpPost("NewPostInsert")]
        public async Task<IActionResult> InsertPost([FromBody] PostInsertUpdateDto data)
        {
            try
            {
                var result = await _crudhandler.Insert<PostDto, PostInsertUpdateDto, PostsTable>(data);
                _logger.LogInformation($"Insert got success");
                return Ok(result);
            }
            catch (Exception ex)
            {
                string message = $"Error during post insert";
                _logger.LogError(ex, message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            } 
        }

    }
}
