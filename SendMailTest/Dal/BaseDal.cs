using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SendMailTest.Dal
{
    public class BaseDal<T>
    {
        /// <summary>
        /// 该构造函数只会调用一次，目的是初始化DapperExtension
        /// </summary>
        static BaseDal()
        {
            SqlMapperExtensions.TableNameMapper = (type) => type.Name;
        }

        /// <summary>
        /// <see cref="IBaseDal{T}.Query(string, object, bool)"/>
        /// </summary>
        public IEnumerable<T> Query(string sql, object parameters = null, bool isReadDb = false)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentNullException("sql");
            }
            IDbConnection conn = null;
            try
            {
                using (conn = GetConnection(isReadDb))
                {
                    return conn.Query<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// <see cref="IBaseDal{T}.Add(T)"/>
        /// </summary>
        public long Add(T entity, IDbTransaction trans = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            IList<T> entities = new List<T>() { entity };
            IDbConnection conn = null;
            try
            {
                if (trans == null)
                {
                    using (conn = GetConnection())
                    {
                        return conn.Insert(entities);
                    }
                }
                else
                {
                    conn = trans.Connection;
                    return conn.Insert(entities, trans);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entities">实体对象</param>
        /// <returns>影响数量</returns>
        public long AddList(IEnumerable<T> entities, IDbTransaction trans = null)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            IDbConnection conn = null;
            try
            {
                if (trans == null)
                {
                    using (conn = GetConnection())
                    {
                        return conn.Insert<IEnumerable<T>>(entities);
                    }
                }
                else
                {
                    conn = trans.Connection;
                    return conn.Insert<IEnumerable<T>>(entities, trans);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// <see cref="IBaseDal{T}.ExecuteWriteSql(string, object)"/>
        /// </summary>
        public int ExecuteWriteSql(string sql, object parameters = null, IDbTransaction trans = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentNullException("sql");
            }
            IDbConnection conn = null;
            try
            {
                if (trans == null)
                {
                    using (conn = GetConnection())
                    {
                        return conn.Execute(sql, parameters);
                    }
                }
                else
                {
                    conn = trans.Connection;
                    return conn.Execute(sql, parameters, trans);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// <see cref="IBaseDal{T}.QueryFirst(string, object, bool)"/>
        /// </summary>
        public T QueryFirst(string sql, object parameters = null, bool isReadDb = false)
        {
            IDbConnection conn = null;
            try
            {
                using (conn = GetConnection(isReadDb))
                {
                    return conn.QueryFirst<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// <see cref="IBaseDal{T}.GetByGuid(string)"/>
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public T GetByGuid(string guid)
        {
            var tableName = typeof(T).Name;
            var sql = $"select * from {tableName} where guid = @guid";
            try
            {
                using (var conn = GetConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@guid", guid);
                    return conn.QueryFirst<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <param name="isWriteDb"></param>
        /// <returns></returns>
        public IDbConnection GetConnection(bool isReadDb = false)
        {
            return new MySqlConnection("server=192.168.0.1;port=3500;user id=;password=;database=;CharSet=utf8;Allow Zero Datetime=true");
        }
    }
}