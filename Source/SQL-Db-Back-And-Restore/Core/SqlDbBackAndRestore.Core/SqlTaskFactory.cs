using System;
using SqlDbBackAndRestore.Core.Contracts;
using SqlDbBackAndRestore.Core.Tasks;

namespace SqlDbBackAndRestore.Core
{
    public class SqlTaskFactory : ISqlTaskFactory
    {
        public ITask GetSqlBackupDbTask(string tableName)
        {
            return new SqlBackUpTask(tableName);
        }

        public ITask GetSqlRestoreDbTast(string tableName)
        {
            return new SqlRestoreTask(tableName);
        }
    }
}
