using CommandAPI.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommandContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("PostreSqlConnection")));

builder.Services.AddControllers();

builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(p => p.MapControllers());

app.Run();
