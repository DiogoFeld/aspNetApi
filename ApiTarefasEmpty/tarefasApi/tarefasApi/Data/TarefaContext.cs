using System.Data;

namespace tarefasApi.Data
{
    public class TarefaContext
    {
        public delegate Task<IDbConnection> GetConnection();

    }
}
