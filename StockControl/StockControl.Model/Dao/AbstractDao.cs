using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Dapper;
using System.Configuration;
using System.Collections.ObjectModel;

namespace StockControl.Model.Dao
{
    public abstract class AbstractDao<T>
    {

        /// <summary>
        /// The table name
        /// </summary>
        private readonly string tableName;

        /// <summary>
        /// Gets the database connection .
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        internal SQLiteConnection Connection
        {
            get
            {
                return new SQLiteConnection(ConfigurationManager.ConnectionStrings["StockBD"].ConnectionString);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}" /> class.         
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        public AbstractDao()
        {
            tableName = typeof(T).Name;
        }
        /// <summary>
        /// Mapping the object to the insert/update columns.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The parameters with values.</returns>
        /// <remarks>In the default case, we take the object as is with no custom mapping.</remarks>
        internal virtual dynamic Mapping(T item)
        {
            return item;
        }
        /// <summary>
        /// 
        /// </summary>        
        /// <returns>returns an IEnumerable</returns>
        public virtual IEnumerable<T> FindAll()
        {
            Connection.Open();
            return Connection.Query<T>("SELECT * FROM " + tableName);
        }
        /// <summary>
        /// Finds by First or Default.
        /// </summary>
        /// <returns></returns>
        public virtual T FindById(int id)
        {
            T item = default(T);

            Connection.Open();
            item = Connection.Query<T>("SELECT * FROM " + tableName + " WHERE " + tableName + "Id="+ id.ToString()).SingleOrDefault();

            return item;
        }
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        internal virtual void Add(T item)
        {
            var parameters = (object)Mapping(item);
            Connection.Open();
            Connection.Insert<int>(tableName, parameters);
        }
        /// <summary>
        /// Modify the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        internal virtual void Modify(T item)
        {
            var parameters = (object)Mapping(item);
            Connection.Open();
            Connection.Modify(tableName, parameters);
        }
        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        internal virtual void Remove(T item)
        {
            Connection.Open();
            Connection.Execute("DELETE FROM " + tableName + " WHERE " + tableName + "Id=@" + tableName + "Id", item);
        }
        /// <summary>
        /// Finds by First or Default.
        /// </summary>
        /// <returns></returns>
        internal virtual T GetFirstOrDefault()
        {
            T item = default(T);

            Connection.Open();
            item = Connection.Query<T>("SELECT * FROM " + tableName + " LIMIT 1").SingleOrDefault();

            return item;
        }
        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>A list of items</returns>
        internal virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> items = null;

            // extract the dynamic sql query and parameters from predicate
            QueryResult result = DynamicQuery.GetDynamicQuery(tableName, predicate);

            Connection.Open();
            items = Connection.Query<T>(result.Sql, (object)result.Param);

            return items;
        }
    }
}
