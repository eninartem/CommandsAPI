using CommandAPI.Data;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json.Serialization;

using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionStringBuilder = new NpgsqlConnectionStringBuilder();
connectionStringBuilder.ConnectionString =
    builder.Configuration.GetConnectionString("PostreSqlConnection");
connectionStringBuilder.Username = builder.Configuration["UserID"];
connectionStringBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<CommandContext>(
    o => o.UseNpgsql(connectionStringBuilder.ConnectionString));

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(p => p.MapControllers());

app.Run();
