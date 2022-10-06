using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
// Cors
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
       policy =>
          {
              policy.WithOrigins("http://localhost:4200");
          });
});

// Add services to the container.
// builder.Services.AddControllers();
// Convert JSON service change to newtonsoft
builder.Services.AddControllers()
 .AddNewtonsoftJson(options =>
  options.SerializerSettings.ContractResolver =
        new CamelCasePropertyNamesContractResolver());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
    RequestPath = "/Photos"
});



app.Run();
