﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace GeneratorBase.MVC.Models
{
    public static class DbSetHelper
    {
        public static IQueryable<TEntity> Unfiltered<TEntity>(this IDbSet<TEntity> set) where TEntity : class
        {
            var filteredDbSet = set as FilteredDbSet<TEntity>;
            return filteredDbSet != null ? filteredDbSet.UnfilteredData() : set;
        }
    }
    public class FilteredDbSet<TEntity> : IDbSet<TEntity>, IOrderedQueryable<TEntity>, IOrderedQueryable, IQueryable<TEntity>, IQueryable, IEnumerable<TEntity>, IEnumerable, IListSource
        where TEntity : class
    {
        private readonly DbSet<TEntity> _set;
        private readonly Action<TEntity> _initializeEntity;
        private readonly Expression<Func<TEntity, bool>> _filter;
        //---------------------------------------------------------------------------
        public FilteredDbSet(DbContext context)
            : this(context.Set<TEntity>(), i => true, null)
        {
        }
        public IQueryable<TEntity> UnfilteredData()
        {
            return _set;
        }
        //---------------------------------------------------------------------------
        public FilteredDbSet(DbContext context, Expression<Func<TEntity, bool>> filter)
            : this(context.Set<TEntity>(), filter, null)
        {
        }
        //---------------------------------------------------------------------------
        public FilteredDbSet(DbContext context, Expression<Func<TEntity, bool>> filter, Action<TEntity> initializeEntity)
            : this(context.Set<TEntity>(), filter, initializeEntity)
        {
        }
        //---------------------------------------------------------------------------
        public Expression<Func<TEntity, bool>> Filter
        {
            get { return _filter; }
        }
        //---------------------------------------------------------------------------
        public IQueryable<TEntity> Include(string path)
        {
            return _set.Include(path).Where(_filter).AsQueryable();
        }
        //---------------------------------------------------------------------------
        private FilteredDbSet(DbSet<TEntity> set, Expression<Func<TEntity, bool>> filter, Action<TEntity> initializeEntity)
        {
            _set = set;
            _filter = filter;
            MatchesFilter = filter.Compile();
            _initializeEntity = initializeEntity;
        }
        //---------------------------------------------------------------------------
        public Func<TEntity, bool> MatchesFilter
        {
            get;
            private set;
        }
        //---------------------------------------------------------------------------
        public IQueryable<TEntity> Unfiltered()
        {
            return _set;
        }
        //---------------------------------------------------------------------------
        public bool ThrowIfEntityDoesNotMatchFilter(TEntity entity)
        {
            try
            {
                if (!MatchesFilter(entity))
                {
                    var context = new System.Web.Routing.RequestContext(
                    new HttpContextWrapper(System.Web.HttpContext.Current),
                    new RouteData());
                    var urlHelper = new UrlHelper(context);
                    var url = urlHelper.Action("Index", "Error");
                    System.Web.HttpContext.Current.Response.Redirect(url);
                    return true;
                }
            }
            catch { return false; }
            return false;            
        }
        //---------------------------------------------------------------------------
        public TEntity Add(TEntity entity)
        {
            DoInitializeEntity(entity);
           // if (ThrowIfEntityDoesNotMatchFilter(entity)) return null;
            return _set.Add(entity);
        }
        //---------------------------------------------------------------------------
        public TEntity Attach(TEntity entity)
        {
            ThrowIfEntityDoesNotMatchFilter(entity);
            return _set.Attach(entity);
        }
        //---------------------------------------------------------------------------
        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity
        {
            var entity = _set.Create<TDerivedEntity>();
            DoInitializeEntity(entity);
            return (TDerivedEntity)entity;
        }
        //---------------------------------------------------------------------------
        public TEntity Create()
        {
            var entity = _set.Create();
            DoInitializeEntity(entity);
            return entity;
        }
        //---------------------------------------------------------------------------
        public TEntity Find(params object[] keyValues)
        {
            var entity = _set.Find(keyValues);//.Where(this.Filter)
            if (entity == null)
                return null;
           // return this._set.Find(keyValues);
            // If the user queried an item outside the filter, then we throw an error.
            // If IDbSet had a Detach method we would use it...sadly, we have to be ok with the item being in the Set.
            ThrowIfEntityDoesNotMatchFilter(entity);
            return entity;
        }
        //---------------------------------------------------------------------------
        public TEntity Remove(TEntity entity)
        {
            ThrowIfEntityDoesNotMatchFilter(entity);
            return _set.Remove(entity);
        }
        //---------------------------------------------------------------------------
        /// <summary>
        /// Returns the items in the local cache
        /// </summary>
        /// <remarks>
        /// It is possible to add/remove entities via this property that do NOT match the filter.
        /// Use the <see cref="ThrowIfEntityDoesNotMatchFilter"/> method before adding/removing an item from this collection.
        /// </remarks>
        public ObservableCollection<TEntity> Local
        {
            get { return _set.Local; }
        }
        //---------------------------------------------------------------------------
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _set.Where(_filter).GetEnumerator();
        }
        //---------------------------------------------------------------------------
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _set.Where(_filter).GetEnumerator();
        }
        //---------------------------------------------------------------------------
        Type IQueryable.ElementType
        {
            get { return typeof(TEntity); }
        }
        //---------------------------------------------------------------------------
        Expression IQueryable.Expression
        {
            get
            {
                return _set.Where(_filter).Expression;
            }
        }
        //---------------------------------------------------------------------------
        IQueryProvider IQueryable.Provider
        {
            get
            {
                return _set.AsQueryable().Provider;
            }
        }
        //---------------------------------------------------------------------------
        bool IListSource.ContainsListCollection
        {
            get { return false; }
        }
        //---------------------------------------------------------------------------
        IList IListSource.GetList()
        {
            throw new InvalidOperationException();
        }
        //---------------------------------------------------------------------------
        void DoInitializeEntity(TEntity entity)
        {
            if (_initializeEntity != null)
                _initializeEntity(entity);
        }
        //---------------------------------------------------------------------------
        public DbSqlQuery<TEntity> SqlQuery(string sql, params object[] parameters)
        {
            return _set.SqlQuery(sql, parameters);
        }
    }
}