using System;
using System.Linq;
using System.Threading.Tasks;
using Articles.Domain;
using Articles.Models;
using Articles.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Articles.Controllers
{
    [Route("articles/{articleId}/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // GET comment/search
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromRoute] int articleId)
        {
            var comments = await _commentRepository
                .Query()
                .Where(comment => comment.ArticleId == articleId)
                .Take(20)
                .ToListAsync();

            var result = new CommentListModel
            {
                Comments = comments.Select(comment => new CommentModel
                {
                    Id = comment.Id,
                    Email = comment.Email,
                    Title = comment.Title,
                    Content = comment.Content,
                    Published = comment.Published    
                })
            };

            return Ok(result);
        }

        // GET comments/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromRoute] int articleId)
        {
            var comments = await _commentRepository
            .Query()
            .Where(comment => comment.ArticleId == articleId)
            .ToListAsync();
            

            var result = new CommentListModel
            {
                Comments = comments.Select(comment => new CommentModel
                {
                    Id = comment.Id,
                    Email = comment.Email,
                    Title = comment.Title,
                    Content = comment.Content,
                    Published = comment.Published    
                })
            };

            return Ok(result);
        }

        // GET comments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, [FromRoute]int articleId)
        {
            var comment = await _commentRepository
            .Query()
            .FirstOrDefaultAsync(comment=> comment.ArticleId == articleId && comment.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            var result = new Comment
            {
                Id = comment.Id,
                Article = comment.Article,
                ArticleId = comment.ArticleId,
                Title = comment.Title,
                Content = comment.Content,
                Date = comment.Date,
                Published = comment.Published
            };

            return Ok(result);
        }


        // article will be null on insert?
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CommentModel model, [FromRoute]int articleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = new Comment
            {
                Id = model.Id,
                ArticleId = articleId,
                Email = model.Email,
                Title = model.Title,
                Content = model.Content,
                Date = DateTime.UtcNow,
                Published = model.Published
            };

            await _commentRepository.InsertAsync(comment);

            return CreatedAtAction(nameof(Get), new {id=comment.Id, articleId=comment.ArticleId}, comment);
        }
    }
}
