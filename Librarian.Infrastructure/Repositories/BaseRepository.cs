using System;
using System.Collections.Generic;
using Librarian.Infrastructure.EntityFramework;
using Librarian.Infrastructure.Repositories.Interface;

namespace Librarian.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly LibraryContext _context;
        protected Microsoft.EntityFrameworkCore.DbSet<T> _entity; 
        public BaseRepository(LibraryContext context)
        {
            this._context = context;
            this._entity =  _context.Set<T>();
          
        }

        public void Delete(Guid id)
        {
            var find = _entity.Find(id);
            if (find == null)
            {
                throw new Exception("Author not found! ");
            }
            else
            {
                _entity.Remove(find);
                Save();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual List<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(Guid id)
        {
            var x = _entity.Find(id);
            if (x == null)
            {
                throw new Exception("Author not found! ");
            }
            return x;
        }

        public void Insert(T insert)
        {
            _entity.Add(insert);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T updated)
        {
            if (updated == null)
            {
                throw new Exception("Author not found! ");
            }
            _context.Entry(updated).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}