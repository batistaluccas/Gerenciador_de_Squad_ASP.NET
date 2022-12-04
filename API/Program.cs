using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(x => { x.SuppressModelStateInvalidFilter = true; });

builder.Services.AddCors(options =>
                    options.AddPolicy("MyPolicy",
                    buider =>
                    {
                        buider
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin();

                    }));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
             var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
             x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}
    );

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => options.SerializeAsV2 = true);
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .GetType());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

