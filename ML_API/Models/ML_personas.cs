using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using ML_API.Data;

namespace ML_personalizacion.Models
{
    public class ML_personas
    {
        [Key]
        public int ML_id { get; set; }
        public string ML_nombre { get; set; }
        public string ML_apellido { get; set; }
        public string ML_email { get; set; }
        public string ML_telefono { get; set; }
    }


public static class ML_personasEndpoints
{
	public static void MapML_personasEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ML_personas").WithTags(nameof(ML_personas));

        group.MapGet("/", async (ML_APIContext db) =>
        {
            return await db.ML_personas.ToListAsync();
        })
        .WithName("GetAllML_personas")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ML_personas>, NotFound>> (int ml_id, ML_APIContext db) =>
        {
            return await db.ML_personas.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ML_id == ml_id)
                is ML_personas model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetML_personasById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int ml_id, ML_personas mL_personas, ML_APIContext db) =>
        {
            var affected = await db.ML_personas
                .Where(model => model.ML_id == ml_id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.ML_id, mL_personas.ML_id)
                  .SetProperty(m => m.ML_nombre, mL_personas.ML_nombre)
                  .SetProperty(m => m.ML_apellido, mL_personas.ML_apellido)
                  .SetProperty(m => m.ML_email, mL_personas.ML_email)
                  .SetProperty(m => m.ML_telefono, mL_personas.ML_telefono)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateML_personas")
        .WithOpenApi();

        group.MapPost("/", async (ML_personas mL_personas, ML_APIContext db) =>
        {
            db.ML_personas.Add(mL_personas);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ML_personas/{mL_personas.ML_id}",mL_personas);
        })
        .WithName("CreateML_personas")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int ml_id, ML_APIContext db) =>
        {
            var affected = await db.ML_personas
                .Where(model => model.ML_id == ml_id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteML_personas")
        .WithOpenApi();
    }
}}
