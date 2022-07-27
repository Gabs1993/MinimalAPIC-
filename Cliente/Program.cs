using Cliente.Data;
using Cliente.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Context>(options => options.UseSqlServer("Server=(localdb)\\localhost;Database=Clientes;Trusted_Connection=True;MultipleActiveResultSets=True"));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("AdicionaCliente", async(Clientes clientes, Context context) =>
    {
        context.Cliente.Add(clientes);
        await context.SaveChangesAsync();
    } );

app.MapDelete("ExcluirCliente/{id}", async (int  id, Context context) =>
{
    var clienteExcluir = context.Cliente.FirstOrDefault(x => x.Id == id);
    if (clienteExcluir != null)
    {
        context.Cliente.Remove(clienteExcluir);
        await context.SaveChangesAsync();
    }
});


app.MapGet("ListarClientes", async ( Context context) =>
{
   return await context.Cliente.ToListAsync();
   
});

app.MapPost("ObterCliente/{id}", async (int id, Context context) =>
{
    return  context.Cliente.FirstOrDefault(x => x.Id == id);
   
});





app.UseSwaggerUI();
app.Run();
