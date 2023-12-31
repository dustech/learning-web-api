var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => 
        {
            c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
        }
    );
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Sample API");
        c.RoutePrefix = "api/swagger";
        }
    );
}

app.UsePathBase(new PathString("/api/"));
app.UseRouting();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
