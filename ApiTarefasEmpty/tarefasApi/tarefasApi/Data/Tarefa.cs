using Dapper.Contrib.Extensions;

namespace tarefasApi.Data
{
    [Table("Tarefas")]
    public record Tarefa(int id, string Atividade, string Status);   
}
