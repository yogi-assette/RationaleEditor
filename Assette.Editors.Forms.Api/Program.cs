using Assette.Editors.Forms.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();


var app = builder.Build();

// Use Swagger middleware
// app.UseSwagger();

app.MapEndpoint();

// Use Swagger UI middleware
// app.UseSwaggerUI();

app.Run();