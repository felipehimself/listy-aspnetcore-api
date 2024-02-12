using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Comment;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {

        private readonly ICommentService _service;

        public CommentsController(ICommentService service)
        {
            _service = service;
        }

        // [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> PostComment(CommentCreateDto comment)
        {
            var comm = comment;
            // var userId = HttpContext.Items["UserId"];

            // if (userId == null) return BadRequest("User not found");

            // Guid id = Guid.Empty;

            // _ = Guid.TryParse(userId.ToString(), out id);

            // comment.UserId = id;

            // 8203ae2c-5097-4a4b-9a93-7bcd0377db72

            comment.UserId = Guid.Parse("8203ae2c-5097-4a4b-9a93-7bcd0377db72");

            return Ok(await _service.AddComment(comment));
        }
    }
}

