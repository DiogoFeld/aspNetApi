using APiCatalogo2.Context;
using APiCatalogo2.Model;
using APiCatalogo2.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using APiCatalogo2.ApiEndpoints;
using APiCatalogo2.AppServicesExtension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAuthenticationJwt();



var app = builder.Build();

app.MapAutenticacaoEndpoints();
app.MapCategoriasEndpoints();
app.MapProdutosEndpoints();


//definir os endpoints
app.MapGet("/", () => "Catalogo de produtos").ExcludeFromDescription();

//CORS

var enviroment = app.Environment;

app.UseExeptionHandling(enviroment)
    .UseSwaggerMiddleware()
    .UseAPPCors();


app.UseAuthentication();
app.UseAuthorization();

app.Run();

