using APiCatalogo2.Context;
using APiCatalogo2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var myConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(myConnection);
});


var app = builder.Build();
//definir os endpoints


app.MapGet("/", () => "Catalogo de produtos").ExcludeFromDescription();


app.MapPost("/categorias", async (Categoria categoria, AppDbContext db)
    =>
{
    db.Categorias.Add(categoria);
    db.SaveChangesAsync();

    return Results.Created($"/categorias/{categoria.CategoriaID}", categoria);
});


app.MapGet("/categorias", async (AppDbContext db) => await db.Categorias.ToListAsync());

app.MapGet("/categoria/{id:int}", async (int id, AppDbContext db) =>
{
    return await db.Categorias.FindAsync(id) is Categoria categoria
    ? Results.Ok(categoria) : Results.NotFound();
});

app.MapPut("/categorias/{id:int}", async (int id, Categoria categoria, AppDbContext db) =>
{
    if (categoria.CategoriaID != id)
    {
        Results.BadRequest();
    }


    var categoriaDB = await db.Categorias.FindAsync(id);

    if (categoriaDB is null)
    {
        return Results.NotFound();
    }

    categoriaDB.Nome = categoria.Nome;
    categoriaDB.Descricao = categoria.Descricao;

    await db.SaveChangesAsync();
    return Results.Ok(categoriaDB);
});


app.MapDelete("/categorias/{id:int}", async (int id, AppDbContext db) =>
{
    var categoriaDB = await db.Categorias.FindAsync(id);

    if (categoriaDB is null)
    {
        return Results.NotFound();
    }

    db.Categorias.Remove(categoriaDB);
    db.SaveChanges();

    return Results.Ok(categoriaDB);
});



//------------------------endpoints para Produto ---------------------------------
app.MapPost("/produtos", async (Produto produto, AppDbContext db)
 => {
     db.Produtos.Add(produto);
     await db.SaveChangesAsync();

     return Results.Created($"/produtos/{produto.ProdutoId}", produto);
 });

app.MapGet("/produtos", async (AppDbContext db) => await db.Produtos.ToListAsync());

app.MapGet("/produtos/{id:int}", async (int id, AppDbContext db)
    => {
        return await db.Produtos.FindAsync(id)
                     is Produto produto
                     ? Results.Ok(produto)
                     : Results.NotFound();
    });

app.MapPut("/produtos/{id:int}", async (int id, Produto produto, AppDbContext db) =>
{

    if (produto.ProdutoId != id)
    {
        return Results.BadRequest();
    }

    var produtoDB = await db.Produtos.FindAsync(id);

    if (produtoDB is null) return Results.NotFound();

    produtoDB.Nome = produto.Nome;
    produtoDB.Descricao = produto.Descricao;
    produtoDB.Preco = produto.Preco;
    produtoDB.imagem = produto.imagem;
    produtoDB.DataCompra = produto.DataCompra;
    produtoDB.Estoque = produto.Estoque;
    produtoDB.imagem = produto.imagem;

    await db.SaveChangesAsync();

    return Results.Ok(produtoDB);
});

app.MapDelete("/produtos/{id:int}", async (int id, AppDbContext db) =>
{
    var produto = await db.Produtos.FindAsync(id);

    if (produto is null)
    {
        return Results.NotFound();
    }

    db.Produtos.Remove(produto);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

