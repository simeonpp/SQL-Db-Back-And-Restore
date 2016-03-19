using System;
using SqlDbBackAndRestore.Core.Contracts;
using SqlDbBackAndRestore.Core.Tasks;

namespace SqlDbBackAndRestore.Core
{
    public class SqlTaskFactory : ISqlTaskFactory
    {
        public ITask GetSqlBackupDbTask(string tableName, string pathToSave)
        {
            return new SqlBackUpTask(tableName, pathToSave);
        }

        public ITask GetSqlRestoreDbTast(string tableName, string restoreFilePath)
        {
            return new SqlRestoreTask(tableName, restoreFilePath);
        }
    }
}
