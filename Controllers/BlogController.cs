using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogUp.dto;
using blogUp.Models;
using blogUp.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blogUp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }


        //get all post
        [HttpGet]
        public async Task<IEnumerable<PostDTO>> GetAllPost()
        {
            try
            {
                var posts = await _context.Blogs.Select(x => new PostDTO
                {
                    id = x.id,
                    author = x.author,
                    avatar = x.avatar,
                    title = x.title,
                    uri = x.uri,
                    createdAt = x.createdAt
                }).ToListAsync();

                return posts;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //get a single post
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogModel>> GetAPost(string id)
        {
            var post = await _context.Blogs.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        //create a post
        [HttpPost]
        public async Task<ActionResult<BlogModel>> CreatePost([FromBody] BlogModel postDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            try
            {
                _context.Blogs.Add(postDTO);
                await _context.SaveChangesAsync();
                return postDTO;
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //edit a post
        [HttpPut("{id}")]
        public async Task<ActionResult<BlogModel>> EditPost(string id, [FromBody] BlogModel postEdit)
        {
            if (id != postEdit.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postEdit);
                    await _context.SaveChangesAsync();
                    return postEdit;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return BadRequest();
        }

        //delete a post
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogModel>> DeletePost(string id)
        {
            var post = await _context.Blogs.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            _context.Blogs.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }
    }
}