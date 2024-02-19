using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        public async Task<IActionResult> Post(CommentCreateDto comment)
        {

            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            comment.UserId = userId;

            return Ok(await _service.AddComment(comment));

        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var userId = new GetUserFromRequest(HttpContext).GetUserId();


            var deleted = await _service.DeleteComment(id, userId);

            return deleted ? NoContent() : NotFound();


        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(CommentUpdateDto comment)
        {

            var userId = new GetUserFromRequest(HttpContext).GetUserId();

            comment.UserId = userId;

            var result = await _service.UpdateComment(comment);

            return result ? Ok() : NotFound();

        }



    }
}

