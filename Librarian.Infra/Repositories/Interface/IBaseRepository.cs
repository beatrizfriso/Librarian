using System;
using System.Collections.Generic;

namespace Librarian.Infrastructure.Repositories.Interface
{
    public interface IBaseRepository<T> : IDisposable where T : class 
    {
       
        List<T> GetAll();
        T GetById(Guid id);
        void Insert(T insert);
        void Delete(Guid id);
        void Update(T updated);

        void Save();
    }
}