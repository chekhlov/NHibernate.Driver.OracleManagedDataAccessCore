using NHibernate.AdoNet;
using NHibernate.Engine;

namespace NHibernate.Driver.OracleManagedDataAccessCore
{
    public class OracleDataClientBatchingBatcherFactory : IBatcherFactory
    {
        public virtual IBatcher CreateBatcher(ConnectionManager connectionManager, IInterceptor interceptor)
        {
            return new OracleDataClientBatchingBatcher(connectionManager, interceptor);
        }
    }
}