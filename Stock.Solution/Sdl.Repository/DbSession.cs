using MySql.Data.MySqlClient;
using Sdl.Base.Orm;
using Sdl.Base.Orm.Mapper;
using Sdl.Base.Orm.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace Sdl.Repository
{
    public sealed class DbSession
    {

        DbSession()
        {

        }

        public DbSession(string connectionString, DbDialect dbType)
        {
            _connectionString = connectionString;
            _dbType = dbType;
        }
        public static IDatabase DatabaseSession { get; private set; }
        private static readonly object SyncRoot = new object();
        private string _connectionString;

        private DbDialect _dbType;

        public IDatabase GetDatabaseSession()
        {

            if (DatabaseSession == null)
            {
                lock (SyncRoot)
                {
                    if (DatabaseSession == null)
                    {
                        BuildDatabaseContext();
                    }
                    return DatabaseSession;
                }
            }
            else
            {
                return DatabaseSession;
            }
        }

        private void BuildDatabaseContext()
        {
            switch (_dbType)
            {
                case DbDialect.SqlServer:
                    var connection = new SqlConnection(_connectionString);
                    var config = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new SqlServerDialect());
                    var sqlGenerator = new SqlGeneratorImpl(config);
                    DatabaseSession = new Database(connection, sqlGenerator);
                    break;
                case DbDialect.Oracle:
                    break;
                case DbDialect.PostgreSql:
                    break;
                case DbDialect.SqlCe:
                    break;
                case DbDialect.Sqlite:
                    break;
                case DbDialect.MySqlDialect:
                    var mysqlConnection = new MySqlConnection(_connectionString);
                    var mysqlConfig = new DapperExtensionsConfiguration(typeof(AutoClassMapper<>), new List<Assembly>(), new MySqlDialect());
                    var mysqlGenerator = new MySqlGenerator(mysqlConfig);
                    DatabaseSession = new Database(mysqlConnection, mysqlGenerator);
                    break;
                default:

                    break;
            }



        }
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
    }

    public enum DbDialect
    {
        /// <summary>
        /// SqlServer
        /// </summary>
        SqlServer = 0,

        /// <summary>
        /// Oracle
        /// </summary>
        Oracle = 1,

        /// <summary>
        /// PostgreSql
        /// </summary>
        PostgreSql = 2,
        /// <summary>
        /// SQL CE
        /// </summary>
        SqlCe = 3,
        /// <summary>
        /// Sqlite
        /// </summary>
        Sqlite = 4,
        /// <summary>
        /// MySQL
        /// </summary>
        MySqlDialect = 5

    }
}
