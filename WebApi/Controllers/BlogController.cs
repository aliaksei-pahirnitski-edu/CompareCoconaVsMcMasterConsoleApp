using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly ISearchCommentsService _commentFinder;
        private readonly ILogger<BlogController> _logger;

        public BlogController(ISearchCommentsService commentFinder, 
            ILogger<BlogController> logger)
        {
            _commentFinder = commentFinder;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Hallo(string? name) => Ok($"Hi {name ?? "Friend"}");

        [HttpGet("comments")]
        public async Task<IActionResult> SearchComments(string query)
        {
            _logger.LogInformation($"Searching comments by [{query}]");
            var comments = await _commentFinder.Search(query);
            _logger.LogInformation($"Found [{comments.Count}] comments");
            return Ok(comments);
        }

    }
}
