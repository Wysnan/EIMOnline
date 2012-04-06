using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Wysnan.EIMOnline.IDAL;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.EF
{
    public class EntityFrameworkModel :IModel, IDisposable
    {
        #region Private Fields

        public readonly DbContext DB;

        //private IDbTransaction dbTransaction;
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
            return List<TType>().FirstOrDefault(o => o.ID == id);
        }

        public TType GetDetached<TType>(int id) where TType : class, IBaseEntity
        {
            var entity = Get<TType>(id);
            DB.Entry(entity).State = EntityState.Detached;
            return entity;
        }


        //public IBaseEntity Get(Type t, int id)
        //{
        //    var type = GetType();
        //    var method = type.GetMethod("GetAll", new[] { typeof(int) });
        //    var genericMethod = method.MakeGenericMethod(new[] { t });
        //    return genericMethod.Invoke(this, new object[] { id }) as IBaseEntity;
        //}

        //public IBaseEntity GetDetached(Type t, int id)
        //{
        //    var entity = Get(t, id);
        //    DB.Entry(entity).State = EntityState.Detached;
        //    return entity;
        //}

        public TType GetAll<TType>(int id) where TType : class, IBaseEntity
        {
            return GetAll<TType>().FirstOrDefault(o => o.ID == id);
        }

        public IQueryable<TType> List<TType>() where TType : class, IBaseEntity
        {
            return GetDbSet<TType>();
        }

        public IQueryable<TType> GetAll<TType>() where TType : class, IBaseEntity
        {
            return GetDbSet<TType>();
        }

        /// <summary>
        /// ªÒ»°DbSet
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        public DbSet<TType> GetDbSet<TType>() where TType : class, IBaseEntity
        {
            return DB.Set<TType>();
        }
        #endregion

        #region Add

        public int Add<TType>(TType entity) where TType : class, IBaseEntity
        {
            if (entity == null) throw new ArgumentNullException("entity");

            //if (entity.SystemStatus == null)
            //{
            //    entity.SystemStatus = SystemStatus.Active;
            //}

            GetDbSet<TType>().Add(entity);
            int i= SaveChanges();
            return i;
        }

        #endregion

        #region Update

        public int Update<TType>(TType entity) where TType : class, IBaseEntity
        {
            if (entity == null) throw new ArgumentNullException("entity");

            var oldEntity = GetDbSet<TType>().Find(entity.ID);
            if (oldEntity == null)
            {
                throw new NullReferenceException(
                    string.Format("Could not retrieve object of EntityType: {0} , ID:{1}", typeof(TType).Name,
                                  entity.ID));
            }

            DB.Entry(oldEntity).CurrentValues.SetValues(entity);
            return SaveChanges();
        }

        #endregion

        #region Delete

        public void LogicDelete<TType>(TType entity) where TType : class, IBaseEntity
        {
            LogicDelete<TType>(entity.ID);
        }

        public void LogicDelete<TType>(int id) where TType : class, IBaseEntity
        {
            var oldObject = GetAll<TType>(id);
            //oldObject.SystemStatus = SystemStatus.Deleted;
            Update(oldObject);
        }

        public int Delete<TType>(TType entity) where TType : class, IBaseEntity
        {
            if (entity == null) throw new ArgumentNullException("entity");

            GetDbSet<TType>().Remove(entity);
            return SaveChanges();

        }

        public void Delete<TType>(int id) where TType : class, IBaseEntity
        {
            var dbSet = GetDbSet<TType>();
            dbSet.Remove(dbSet.Find(id));
            SaveChanges();
        }

        public void Undelete<TType>(int id) where TType : class, IBaseEntity
        {
            var oldObject = GetAll<TType>(id);
            //oldObject.SystemStatus = SystemStatus.Active;
            Update(oldObject);
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

        private int SaveChanges()
        {
            try
            {
                return DB.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                //foreach (var eve in e.EntityValidationErrors)
                //{
                //    Logger.Instance.Error(
                //        System.Reflection.MethodBase.GetCurrentMethod(),
                //        "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //    foreach (var ve in eve.ValidationErrors)
                //    {
                //        Logger.Instance.Error(
                //            System.Reflection.MethodBase.GetCurrentMethod(),
                //            "- Property: \"{0}\", Error: \"{1}\"",
                //            ve.PropertyName, ve.ErrorMessage);
                //    }
                //}
                throw;
            }
        }
        #endregion

    }
}