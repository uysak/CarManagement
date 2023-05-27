using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository <TEntity> where TEntity : class, IEntity
    {
        public void Add(TEntity entity);
        public TEntity Get(Expression<Func<TEntity, bool>> filter);
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
