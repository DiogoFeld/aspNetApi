using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Builder;
using tarefasApi.Data;
using static tarefasApi.Data.TarefaContext;

namespace tarefasApi.EndPoints
{
    public static class TarefasEndpoint
    {
        public static void MapTarefasEndPoints(this WebApplication app)
        {
            app.MapGet("/", () => $"Bem vindo a api tarefas {DateTime.Now}");


            app.MapGet("/tarefas", async (GetConnection connetionGetter) =>
            {
                using var con = await connetionGetter();
                var tarefas = con.GetAll<Tarefa>().ToList();
                if(tarefas is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(tarefas);
            });

            app.MapGet("/tarefas/{id}", async (GetConnection connetionGetter, int id) =>
            {
                using var con = await connetionGetter();
                var tarefa = con.Get<Tarefa>(id);
                if (tarefa is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(tarefa);
            });

            app.MapPost("tarefas", async (GetConnection connetionGetter, Tarefa tarefa_) =>
            {
                using var con = await connetionGetter();
                var id = con.Insert(tarefa_);
                
                return Results.Created($"tarefa id = {id}", tarefa_);                
            });

            app.MapPut("tarefas", async (GetConnection connetionGetter, Tarefa tarefa_) =>
            {
                using var con = await connetionGetter();
                var id = con.Update(tarefa_);
                
                return Results.Created($"tarefa id = {id}", tarefa_);                
            });

            app.MapDelete("/tarefas/{id}", async (GetConnection connetionGetter, int id) =>
            {
                using var con = await connetionGetter();
                var deleted  = con.Get<Tarefa>(id);
                if (deleted is null)
                {
                    return Results.NotFound();
                }
                con.Delete(deleted);
                return Results.Ok(deleted);
            });

        }
    }
}
