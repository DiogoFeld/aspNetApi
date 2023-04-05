using tarefasApi.EndPoints;
using tarefasApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddPersistence();



var app = builder.Build();
app.MapTarefasEndPoints();

app.Run();
