using System;

namespace Librarian.Application.DTOs.Exceptions
{
    public class BadRequest
    {
        public BadRequest(Exception ex)
        {
            Name = ex.Message;
            StackTrace = ex.StackTrace.ToString();
        }

        public string Name { get; set; }
        public string StackTrace { get; set; }

    }
}