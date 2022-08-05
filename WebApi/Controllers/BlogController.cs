using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly ISearchCommentsService _commentFinder;
        private readonly ILogger<BlogController> _logger;

        public BlogController(
            IBlogService blogService,
            ISearchCommentsService commentFinder, 
            ILogger<BlogController> logger)
        {
            _blogService = blogService;
            _commentFinder = commentFinder;
            _logger = logger;
        }

        [HttpGet("hallo")]
        public IActionResult Hallo(string? name) => Ok($"Hi {name ?? "Friend"}");

        [HttpGet()]
        public async Task<IActionResult> List(int count = 3, bool withComments = false)
        {
            _logger.LogInformation($"List {count} blogs [{(withComments ? "with comments" : "")}]");
            var topBlogs = await _blogService.ListBlogs(count, withComments);
            return Ok(topBlogs);
        }

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
