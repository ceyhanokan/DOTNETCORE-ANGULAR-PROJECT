using Core.Entities;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessCore.EntityFWC
{
    public class EFC_RepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public InsertResult<TEntity> Add(TEntity Entity)
        {
            InsertResult<TEntity> result = new InsertResult<TEntity>();
            using (var context =  new TContext())
            {
                var addedEntity = context.Entry(Entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                result.IsSuccess = true;
                result.Message = "Başarılı";
                result.InsertedRecord = addedEntity.Entity;
            }
            return result;
        }

        public InsertResult<TEntity> AddMultiple(IList<TEntity> Entitys)
        {
            InsertResult<TEntity> result = new InsertResult<TEntity>();
            using (var context = new TContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in Entitys)
                        {
                            var addedEntity = context.Entry(item);
                            addedEntity.State = EntityState.Added;
                            result.InsertedMultipleRecords.Add(item);
                            context.SaveChanges();
                            result.IsSuccess = true;
                        }
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        context.Database.RollbackTransaction();
                        result.IsSuccess = false;
                        result.Ex = ex;
                        //hata oluştu log kaydet vs ex.
                    }
                    
                }

            }
            return result;
        }

        public DeleteResult<TEntity> Detele(TEntity Entity)
        {
            var result = new DeleteResult<TEntity>();
            using (var context = new TContext())
            {

                var addedEntity = context.Entry(Entity);
                addedEntity.State = EntityState.Deleted;
                result.IsSuccess = true;
                result.DeletedRecord = addedEntity.Entity;
                context.SaveChanges();
            }
            return result;
        }

        public SelectResult<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, int skip = 0, int take = 100)
        {
            SelectResult<TEntity> result = new SelectResult<TEntity>();
            using (var context = new TContext())
            {
                result.RecordList = filter == null 
                    ? context.Set<TEntity>().Skip(skip).Take(take).ToList()
                    : context.Set<TEntity>().Where(filter).Skip(skip).Take(take).ToList();
                result.IsSuccess = true;
                result.TotalRecord = context.Set<TEntity>().Count();
                result.FilteredRecord = filter == null ? result.TotalRecord : context.Set<TEntity>().Where(filter).Count();
            }
            return result;
        }

        public async Task<SelectResult<TEntity>> GetListAsync(int skip, int take, Expression<Func<TEntity, bool>> filter = null)
        {
            var result = new SelectResult<TEntity>();
            using (var context = new TContext())
            {
                var r =  filter == null
                    ? context.Set<TEntity>().Skip(skip).Take(take)
                    : context.Set<TEntity>().Where(filter).Skip(skip).Take(take);
                result.RecordList = await r.ToListAsync().ConfigureAwait(false);
                result.IsSuccess = true;
            }
            return result;
        }

        public SelectResult<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter)
        {
            var result = new SelectResult<TEntity>();
            using (var context = new TContext())
            {
                result.RecordSingle = context.Set<TEntity>().SingleOrDefault(filter);
                result.IsSuccess = true;
            }
            return result;
        }

        public async Task<SelectResult<TEntity>> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            SelectResult<TEntity> result = new SelectResult<TEntity>();
            using (var context = new TContext())
            {
                var r = context.Set<TEntity>();
                result.RecordSingle = await r.FirstOrDefaultAsync(filter);
                result.IsSuccess = true;
            }
            return result;
        }
        public UpdateResult<TEntity> Update(TEntity Entity)
        {
            var result = new UpdateResult<TEntity>();
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(Entity);
                updatedEntity.State = EntityState.Modified;
                result.IsSuccess = true;
                result.UpdatedRecord = updatedEntity.Entity;
                context.SaveChanges();
            }
            return result;
        }
    }
}
