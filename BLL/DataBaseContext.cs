using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using Blog.Models;
namespace Blog
{
    public class DataBaseContext<T> where T : class, new() 
    {
        private DbContext blogContext;
        private DbSet<T> dbSet;
        private DataBaseContext(BlogContext context)
        {
            context = new BlogContext();
            this.blogContext = context;
            this.dbSet = blogContext.Set<T>();
        }
        public DataBaseContext()
        {
            BlogContext context = new BlogContext();
            this.blogContext = context;
            this.dbSet = blogContext.Set<T>();
        }
        /// <summary>
        /// 返回全部数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetListAll()
        {
            return dbSet.ToList();
        }
        public T Get(Expression<Func<T, bool>> wherestr)
        {
            return dbSet.Where(wherestr).FirstOrDefault();
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="wherestr"></param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> wherestr) 
        {
            return dbSet.Where(wherestr).ToList();
        }
        /// <summary>
        /// sql语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> GetList(string sql)
        {
            return dbSet.SqlQuery(sql).ToList(); 
        }
        /// <summary>
        /// 更新
        /// </summary>
        public void Update(T model)
        {
            if (blogContext.Entry<T>(model).State == EntityState.Modified)
            {
                blogContext.SaveChanges();
            }
            else
            {
                blogContext.Set<T>().Attach(model);
                blogContext.SaveChanges();
            }
        }

        public void Add(T model)
        {
            if (model != null)
            {
                blogContext.Entry<T>(model).State = EntityState.Added;
                blogContext.SaveChanges();
            }
        }
    }

    
}
