using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using Wysnan.EIMOnline.IDAL;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.EF
{
    public class EntityFrameworkModel : IModel, IDisposable
    {
        #region Private Fields

        public readonly DbContext DB;

        #endregion

        #region .ctor

        public EntityFrameworkModel()
            : this(new Context())
        {

        }

        public EntityFrameworkModel(DbContext context)
        {
            DB = context;
            InitContext();
        }

        /// <summary>
        /// 设置DBContext
        /// </summary>
        private void InitContext()
        {
            /* true by default
                        DB.Configuration.LazyLoadingEnabled = true;
            */
        }
        #endregion

        #region IModel Members

        #region Get

        public TType Get<TType>(int id) where TType : class, IBaseEntity
        {
            return List<TType>().FirstOrDefault(o => o.ID == id && o.SystemStatus == (int)SystemStatus.Active);
        }

        public IQueryable<TType> List<TType>() where TType : class, IBaseEntity
        {
            return GetDbSet<TType>().Where(a => a.SystemStatus.HasValue && a.SystemStatus == (int)SystemStatus.Active); 
        }

        #endregion

        #region Add

        public Result Add<TType>(TType entity) where TType : class, IBaseEntity
        {
            Result result = new Result();
            if (entity == null)
            {
                result.MessageCode = "1";
                return result;
            }
            if (entity.SystemStatus == null)
            {
                entity.SystemStatus = (byte)SystemStatus.Active;
            }
            if (entity is IModificationTrackableEntity)
            {
                IModificationTrackableEntity modificationTrackable = entity as IModificationTrackableEntity;
                modificationTrackable.CreatedOn = DateTime.Now;
                modificationTrackable.ModifiedOn = DateTime.Now;
                //Type type = entity.GetType();
                //type.GetProperties("")
            }

            GetDbSet<TType>().Add(entity);
            return SaveChanges();
        }

        #endregion

        #region Update

        public Result Update<TType>(TType entity) where TType : class, IBaseEntity
        {
            Result result = new Result();
            if (entity == null)
            {
                result.MessageCode = "1";
                return result;
            }

            var oldEntity = GetDbSet<TType>().Find(entity.ID);
            if (oldEntity == null)
            {
                result.MessageCode = "2";
                result.Params = new string[] { typeof(TType).Name, entity.ID.ToString() };
                return result;
            }
            if (oldEntity.SystemStatus == (int)SystemStatus.Active)
            {
                result.MessageCode = "5";
                result.Params = new string[] { typeof(TType).Name, entity.ID.ToString() };
                return result;
            }
            try
            {
                DB.Entry(oldEntity).CurrentValues.SetValues(entity);
                return SaveChanges();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            finally
            {
                Dispose();
            }
        }

        #endregion

        #region Delete

        public Result LogicDelete<TType>(TType entity) where TType : class, IBaseEntity
        {
            Result result = new Result();
            if (entity == null)
            {
                result.MessageCode = "2";
                result.Params = new string[] { typeof(TType).Name, entity.ID.ToString() };
                return result;
            }
            return LogicDelete<TType>(entity.ID);
        }

        public Result LogicDelete<TType>(int id) where TType : class, IBaseEntity
        {
            Result result = new Result();
            if (id < 0)
            {
                result.MessageCode = "3";
                result.Params = new string[] { typeof(TType).Name, id.ToString() };
                return result;
            }
            var oldObject = Get<TType>(id);
            if (oldObject == null)
            {
                result.MessageCode = "2";
                result.Params = new string[] { typeof(TType).Name, id.ToString() };
                return result;
            }
            oldObject.SystemStatus = (byte)SystemStatus.Deleted;
            return Update(oldObject);
        }

        public Result Delete<TType>(TType entity) where TType : class, IBaseEntity
        {
            Result result = new Result();
            if (entity == null)
            {
                result.MessageCode = "2";
                result.Params = new string[] { typeof(TType).Name, entity.ID.ToString() };
                return result;
            }
            try
            {
                GetDbSet<TType>().Remove(entity);
                return SaveChanges();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            finally
            {
                Dispose();
            }
        }

        public Result Delete<TType>(int id) where TType : class, IBaseEntity
        {
            Result result = new Result();
            if (id < 0)
            {
                result.MessageCode = "3";
                result.Params = new string[] { typeof(TType).Name, id.ToString() };
                return result;
            }
            var dbSet = GetDbSet<TType>();
            var entity = dbSet.Find(id);
            if (entity == null)
            {
                result.MessageCode = "2";
                result.Params = new string[] { typeof(TType).Name, id.ToString() };
                return result;
            }
            try
            {
                dbSet.Remove(entity);
                return SaveChanges();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            finally
            {
                Dispose();
            }

        }

        public Result Undelete<TType>(int id) where TType : class, IBaseEntity
        {
            Result result = new Result();
            if (id < 0)
            {
                result.MessageCode = "3";
                result.Params = new string[] { typeof(TType).Name, id.ToString() };
                return result;
            }
            var oldObject = Get<TType>(id);
            if (oldObject == null)
            {
                result.MessageCode = "2";
                result.Params = new string[] { typeof(TType).Name, id.ToString() };
                return result;
            }
            oldObject.SystemStatus = (byte)SystemStatus.Active;
            return Update(oldObject);
        }
        #endregion

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            DB.Dispose();
        }

        #endregion

        #region Business Methods

        private Result SaveChanges()
        {
            Result result = new Result();
            try
            {
                int i = DB.SaveChanges();
                return result;
            }
            catch (DbEntityValidationException e)
            {
                result.Message = e.Message;
                return result;
            }
            //finally
            //{
            //    Dispose();
            //}
        }

        private DbSet<TType> GetDbSet<TType>() where TType : class, IBaseEntity
        {
            return DB.Set<TType>();
        }

        //public TType GetDetached<TType>(int id) where TType : class, IBaseEntity
        //{
        //    var entity = Get<TType>(id);
        //    DB.Entry(entity).State = EntityState.Detached;
        //    return entity;
        //}

        //public TType GetAll<TType>(int id) where TType : class, IBaseEntity
        //{
        //    return GetAll<TType>().FirstOrDefault(o => o.ID == id);
        //}

        #endregion



    }
}