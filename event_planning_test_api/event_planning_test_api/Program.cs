using event_planning_test_api.Infrastructure.Configuration;
using Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppSettings();
// Add services to the container.
builder.Services.ConfigureOptions(builder.Configuration);
builder.Services.ConfigureCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(CorsConfiguration.AllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();
