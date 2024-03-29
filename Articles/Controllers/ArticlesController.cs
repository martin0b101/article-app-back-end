﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Articles.Domain;
using Articles.Models;
using Articles.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Articles.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        // GET articles/search
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery]string title)
        {
            var articles = await _articleRepository
                .Query()
                .Where(a => a.Title.Contains(title) || a.Content.Contains(title))
                .Take(20)
                .ToListAsync();

            var result = new ArticleListModel
            {
                Articles = articles.Select(a => new ArticleModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Date = a.Date,
                    Published = a.Published
                })
            };

            return Ok(result);
        }

        // articles/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var articles = await _articleRepository.GetAllAsync();

             var result = new ArticleListModel
            {
                Articles = articles.Select(a => new ArticleModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Date = a.Date,
                    Published = a.Published
                })
            };
            return Ok(result);
        }

        // GET articles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var article = await _articleRepository.GetAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            var result = new ArticleModel
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                Date = article.Date,
                Published = article.Published
            };

            return Ok(result);
        }

        // POST articles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ArticleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = new Article
            {
                Title = model.Title,
                Content = model.Content,
                Date = DateTime.UtcNow,
                Published = model.Published
            };

            await _articleRepository.InsertAsync(article);

            return CreatedAtAction(nameof(Get), new {id=article.Id}, article);
        }

        // PUT articles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ArticleModel model)
        {
            var article = await _articleRepository.GetAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            article.Title = model.Title;
            article.Published = model.Published;
            article.Content = model.Content;

            await _articleRepository.UpdateAsync(article);
           
            return Ok(article);
        }

        // DELETE articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _articleRepository.GetAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            await _articleRepository.DeleteAsync(article);

            return NoContent();
        }
    }
}
