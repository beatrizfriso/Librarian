using System;
using System.Collections.Generic;
using Librarian.Application.DTOs.Request;
using Librarian.Application.DTOs.Request.Author;
using Librarian.Application.DTOs.Request.Genre;
using Librarian.Application.DTOs.Response;
using Librarian.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.WebAPI.Controllers;

[Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost("post")]
        public IActionResult AddGenre([FromBody] GenreRequest newGenreRequest)
        {
            try
            {
                var genre = _genreService.InsertGenre(newGenreRequest);

                return Ok(new { status = "Criado", genre.Uid });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Name = "Couldn't insert book !", ex.StackTrace });

            }
        }

        [HttpGet("GetByUid/{Uid:Guid}")]
        public IActionResult GetByUid(Guid Uid)
        {
            try
            {
                var request = new GetByIdRequest { Uid = Uid };
                var response = _genreService.GetById(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new {Name = "Genre not find !", ex.StackTrace});
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCategoryByUid([FromBody] Guid id)
        {
            try
            {
                var delete = _genreService.DeleteGenre(id);
                return Ok(new { status = "Deletado"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { Name = "Genre not find !", ex.StackTrace });
            }
        }

        [HttpPut("update")]

        public IActionResult UpdateGenre(UpdateAuthorRequest updatedGenre)
        {
            try
            {
                var request = _genreService.UpdateGenre(updatedGenre);
                return Ok(new { status = "Updated", request.Uid });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Name = "Genre not find !", ex.StackTrace });
            }
        }

        [HttpGet("all")]

        public ActionResult<List<GenreResponse>> GetAll()
        {
            return Ok(_genreService.GetAll());
        }
    }
