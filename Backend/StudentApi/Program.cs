using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// --- [ÅÖÇİÉ ÎÏãÉ CORS åäÇ] ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()    // íÓãÍ ÈØáÈÇÊ ãä Ãí ãßÇä
              .AllowAnyMethod()    // íÓãÍ ÈÌãíÚ ÇáÚãáíÇÊ (GET, POST, PUT, DELETE)
              .AllowAnyHeader();   // íÓãÍ ÈÌãíÚ ÇáÊÑæíÓÇÊ
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Student Management API",
        Version = "v1",
        Description = "RESTful API for managing students",
        Contact = new OpenApiContact
        {
            Name = "Mohamed Abass",
            Email = "Mohamed.Abass.pro@gmail.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student API V1");
        c.DocumentTitle = "Student Management API";
    });
}

// --- [ÊİÚíá CORS åäÇ] ---
// ãáÇÍÙÉ åÇãÉ: íÌÈ æÖÚ UseCors ŞÈá UseAuthorization æ UseHttpsRedirection áÖãÇä ÚãáåÇ ÈÔßá ÕÍíÍ
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();