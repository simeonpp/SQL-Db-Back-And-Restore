using System;
using SqlDbBackAndRestore.Core.Contracts;
using SqlDbBackAndRestore.Core.Tasks;
using System.Text.RegularExpressions;

namespace SqlDbBackAndRestore.Core
{
    public class SqlTaskFactory : ISqlTaskFactory
    {
        public ITask GetSqlBackupDbTask(string connectionString, string pathToSave)
        {
            string databaseName = this.GetDatabaseNameFromConnectionString(connectionString);
            return new SqlBackUpTask(connectionString, databaseName, pathToSave);
        }

        public ITask GetSqlRestoreDbTask(string connectionString, string restoreFilePath)
        {
            string databaseName = this.GetDatabaseNameFromConnectionString(connectionString);
            return new SqlRestoreTask(connectionString, databaseName, restoreFilePath);
        }

        public string GetDatabaseNameFromConnectionString(string connectionString)
        {
            string databaseName = Regex.Match(connectionString, @"Initial Catalog=([^;]*)\;").Groups[1].Value;
            return databaseName;
        }
    }
}
