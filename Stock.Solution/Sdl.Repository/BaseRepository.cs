using Sdl.Base.Orm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sdl.Repository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        #region CURD
        T Get(object id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(IFieldPredicate predicate);
        //GetMultiplePredicate
        IEnumerable<T> GetAll(GetMultiplePredicate predicate);
        IEnumerable<T> GetPage(IList<ISort> sort, int page, int resultsPerPage);
        IEnumerable<T> GetPage(IFieldPredicate predicate, IList<ISort> sort, int page, int resultsPerPage);

        //IEnumerable<T> ExecuteStoredProcedure(string procName, params IDataParameter[] parms);
        //DataSet ExecuteDataSet(string sql, Dictionary<string, object> parms = null);
        //object ExecuteScalar(string sql, Dictionary<string, object> parms = null);
        //IDataReader ExecuteReader(string sql, Dictionary<string, object> parms = null);
        int ExecuteNonQuery(string sql, Dictionary<string, object> parms = null);
        IEnumerable<T> GetSearchPage(SearchBase search);
        void Insert(T model);
        void Update(T model);
        bool Delete(T model);
        #endregion

    }
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        //[Dependency]
        public virtual DbSession dbSession { get; set; }

        public BaseRepository()
        {
            dbSession = new DbSession("server=.;database=Stock;uid=sa;pwd=1", DbDialect.SqlServer);
        }

        protected virtual IDatabase Db
        {
            //get;
            get { return dbSession.GetDatabaseSession(); }
        }

        public bool Delete(T model)
        {
            try
            {
                return Db.Delete(model);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Get(object id)
        {
            try
            {
                //using (Db)
                return Db.Get<T>(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return Db.GetList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll(IFieldPredicate predicate)
        {
            try
            {
                //using (Db)
                return Db.GetList<T>(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll(GetMultiplePredicate predicate)
        {
            try
            {
                using (Db)
                    return Db.GetList<T>(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetPage(IList<ISort> sort, int page, int resultsPerPage)
        {
            try
            {
                //using (Db)
                return Db.GetPage<T>(null, sort, page, resultsPerPage);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object ExecuteScalar(string sql, Dictionary<string, object> parms = null)
        {
            try
            {
                //using (Db)
                return Db.ExecuteScalar(sql, parms);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public int ExecuteNonQuery(string sql, Dictionary<string, object> parms = null)
        {
            try
            {
                using (Db)
                    return Db.ExecuteNonQuery(sql, parms);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetPage(IFieldPredicate predicate, IList<ISort> sort, int page, int resultsPerPage)
        {
            try
            {
                using (Db)
                    return Db.GetPage<T>(predicate, sort, page, resultsPerPage);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert(T model)
        {
            try
            {
                using (Db)
                    Db.Insert<T>(model);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Update(T model)
        {
            try
            {
                using (Db)
                    Db.Update<T>(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetSearchPage(SearchBase search)
        {
            if (search.sort == null)
            {
                search.sort = new List<ISort>();
                search.sort.Add(new Sort() { PropertyName = "ID", Ascending = true });
            }
            search.totalCount = Db.Count<T>(search.predicate);
            return Db.GetPage<T>(search.predicate, search.sort, search.currentPage, search.pageSize);

        }
    }
}