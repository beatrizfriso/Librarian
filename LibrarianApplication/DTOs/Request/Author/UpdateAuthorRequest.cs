using System;

namespace Librarian.Application.DTOs.Request.Author
{
    public class UpdateAuthorRequest
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
    }
}