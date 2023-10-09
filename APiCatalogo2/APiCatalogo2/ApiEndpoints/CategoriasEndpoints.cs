using APiCatalogo2.Context;
using APiCatalogo2.Model;
using Microsoft.EntityFrameworkCore;

namespace APiCatalogo2.ApiEndpoints
{
    public static class CategoriasEndpoints
    {
        public static void MapCategoriasEndpoints(this WebApplication app)
        {


            app.MapPost("/categorias", async (Categoria categoria, AppDbContext db)
                =>
            {
                db.Categorias.Add(categoria);
                db.SaveChangesAsync();

                return Results.Created($"/categorias/{categoria.CategoriaID}", categoria);
            });


            app.MapGet("/categorias", async (AppDbContext db) => await db.Categorias.ToListAsync()).RequireAuthorization();

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


        }




    }
}
