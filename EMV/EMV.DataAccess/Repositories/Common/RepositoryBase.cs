using EMV.Contracts;
using EMV.DataAccess.Contexts;
using EMV.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.DataAccess.Repositories.Common
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList(); // Obtener todos los registros
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id); // Obtener un registro por ID
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity); // Agregar un nuevo registro
            _context.SaveChanges(); // Guardar cambios en la base de datos
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity); // Actualizar un registro existente
            _context.SaveChanges(); // Guardar cambios en la base de datos
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity); // Eliminar el registro
                _context.SaveChanges(); // Guardar cambios en la base de datos
            }
        }
    }
}
