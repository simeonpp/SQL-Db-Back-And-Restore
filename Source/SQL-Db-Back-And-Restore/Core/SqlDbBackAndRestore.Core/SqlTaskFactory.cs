using System;
using SqlDbBackAndRestore.Core.Contracts;
using SqlDbBackAndRestore.Core.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace SqlDbBackAndRestore.Core
{
    public class SqlTaskFactory : ISqlTaskFactory
    {
        public ITask GetSqlBackupDbTask(string connectionString, string pathToSave)
        {
            string databaseName = this.GetDatabaseNameFromConnectionString(connectionString);
            string nowTimestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string filePath = string.Format("{0}\\{1}-{2}.bak", pathToSave, databaseName, nowTimestamp);

            string sql = string.Format("BACKUP DATABASE {0} TO DISK = '{1}'", databaseName, filePath);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            return new SqlBackUpTask(connection, command, databaseName);
        }

        public ITask GetSqlRestoreDbTask(string connectionString, string restoreFilePath)
        {
            string databaseName = this.GetDatabaseNameFromConnectionString(connectionString);
            string sql = "USE master;";
            sql += string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", databaseName);
            sql += string.Format("RESTORE DATABASE {0} FROM DISk = '{1}' WITH REPLACE", databaseName, restoreFilePath);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            
            return new SqlRestoreTask(connection, command, databaseName);
        }

        public string GetDatabaseNameFromConnectionString(string connectionString)
        {
            string databaseName = Regex.Match(connectionString, @"Initial Catalog=([^;]*)\;").Groups[1].Value;
            return databaseName;
        }
    }
}
