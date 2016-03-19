using System;
using SqlDbBackAndRestore.Core.Contracts;
using SqlDbBackAndRestore.Core.Tasks;

namespace SqlDbBackAndRestore.Core
{
    public class SqlTaskFactory : ISqlTaskFactory
    {
        public ITask GetSqlBackupDbTask(string databaseName, string pathToSave)
        {
            return new SqlBackUpTask(databaseName, pathToSave);
        }

        public ITask GetSqlRestoreDbTast(string databaseName, string restoreFilePath)
        {
            return new SqlRestoreTask(databaseName, restoreFilePath);
        }
    }
}
