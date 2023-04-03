using System;

namespace Librarian.Application.DTOs.Request.Genre
{
    public class UpdateGenreRequest
    {
        [Required]
        public Guid Uid { get; set; }
        public string Name { get; set; }
    }
}