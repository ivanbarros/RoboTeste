using Robo.Core.Configurations.Automapper;
using Robo.Core.Configurations.Database;
using Robo.Core.Configurations.DependencyInjection;
using Robo.Core.Configurations.Mediator;
using Robo.Core.Configurations.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerFramework(builder.Environment,builder.Configuration);
builder.Services.ConfigureAutomapper();
builder.Services.ConfigureDependenciesRepositories();
builder.Services.ConfigureDependenciesService(builder.Configuration);
MigratorServices.CreateService(builder.Configuration["sqlDb:connectionString"]);
builder.Services.AddSqlConfiguration(builder.Configuration);
builder.Services.ConfigureMediator();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
