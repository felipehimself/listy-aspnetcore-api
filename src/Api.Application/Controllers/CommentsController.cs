using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.CrossCutting.Helpers;
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

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> PostComment(CommentCreateDto comment)
        {

            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            // if (userId == null) return Unauthorized();

            try
            {
                comment.UserId = userId;

                return Ok(await _service.AddComment(comment));
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                throw;
            }
        }
    }
}

