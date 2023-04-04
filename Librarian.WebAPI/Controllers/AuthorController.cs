using System;
using System.Collections.Generic;
using Librarian.Application.DTOs.Exceptions;
using Librarian.Application.DTOs.Request;
using Librarian.Application.DTOs.Request.Author;
using Librarian.Application.DTOs.Response;
using Librarian.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Librarian.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
    
    [HttpPost]
    public IActionResult AddAuthor([FromBody] AuthorRequest newAuthorRequest)
    {
        var author = _authorService.InsertAuthor(newAuthorRequest);
        return Ok(new { status = "Created", author.Uid });
    }
        
    [HttpGet]
    public IActionResult GetByUid(Guid Uid)
    {
        try
        {
            var request = new GetByIdRequest { Uid = Uid };
            var response = _authorService.GetById(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new BadRequest(ex));
        }
    }

    [HttpPut]
    public IActionResult UpdateAuthor(UpdateAuthorRequest updatedAuthor)
    {
        try 
        {
            var author = _authorService.UpdateAuthor(updatedAuthor);
            return Ok(new { status = "Updated", author.Uid });
        }
        catch (Exception ex)
        {
            return BadRequest(new BadRequest(ex));
        }
    }

    [HttpDelete]
    public IActionResult DeleteAuthorByUid([FromBody] Guid id)
    {
        try
        {
            _authorService.DeleteAuthor(id);

            return Ok(new { status = "Deleted" });
        }
        catch (Exception ex)
        {
            return BadRequest(new BadRequest(ex));
        }
    }

    [HttpGet(template:"all")]
    public ActionResult<List<AuthorResponse>> GetAll()
    {
        return Ok(_authorService.GetAll());
    }
}
