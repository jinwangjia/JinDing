using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlDal
{
    public static class EFExt
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="TSource">任何数据类</typeparam>
        /// <param name="source">任何linq</param>
        /// <param name="rowsOfPage">每页行数</param>
        /// <param name="page">页号（从1开始）</param>
        /// <returns></returns>
        public static IQueryable<TSource> Paged<TSource>(this IQueryable<TSource> source,int rowsOfPage ,int page )
        {
            page = -1;
            return source.Skip((page) * rowsOfPage).Take(rowsOfPage);
        }

        /// <summary>
        /// 不能用
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static IQueryable<TSource> Between<TSource, TKey>(this IQueryable<TSource> source,
                Expression<Func<TSource, TKey>> keySelector,
                TKey low,
                TKey high) where TKey : IComparable<TKey>
        {
            Expression key = Expression.Invoke(keySelector, keySelector.Parameters.ToArray());
            Expression lowerBound = Expression.GreaterThanOrEqual(key, Expression.Constant(low));
            Expression upperBound = Expression.LessThan(key, Expression.Constant(high));
            Expression and = Expression.AndAlso(lowerBound, upperBound);
            Expression<Func<TSource, bool>> lambda = Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);
            return source.Where(lambda.Compile()).AsQueryable();
        }
    }

    public class ParentDal<T> where T : class
    {




        //public void ExecuteNonQuery(string sql)
        //{
        //    using (var dal = new BaseDal())
        //    {
        //        dal.Database.ExecuteNonQuery(sql);
        //    }
        //}

        public void Clear()
        {
            using (var dal = new BaseDal())
            {
                var list = (from o in dal.Set<T>() select o).ToList();
                dal.Set<T>().RemoveRange(list);
                dal.SaveChanges();
            }
        }

        public virtual void Add(T p)
        {
            using (var bll = new BaseDal())
            {
                bll.Set<T>().Add(p);
                bll.SaveChanges();
            }
        }

        public T Find(params object[] p)
        {
            using (var bll = new BaseDal())
            {
                return bll.Set<T>().Find(p);
            }
        }

        public virtual IList<T> Query()
        {
            using (var bll = new BaseDal())
            {
                return (from o in bll.Set<T>() select o).AsNoTracking().ToList();
            }
        }



        public virtual void Remove(T p)
        {
            using (var bll = new BaseDal())
            {
                bll.Set<T>().Attach(p);
                bll.Set<T>().Remove(p);
                bll.SaveChanges();
            }
        }

        public virtual void Update(T p)
        {
            using (var bll = new BaseDal())
            {
                bll.Entry(p).State = EntityState.Modified;
                bll.SaveChanges();
            }
        }
    }



}