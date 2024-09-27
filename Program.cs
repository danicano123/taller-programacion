using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using taller_programacion.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
// Db connection
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("taller-programacion-db"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2-Mysql"));
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DBContext dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();
    dbContext.Database.Migrate();  // Este comando aplica las migraciones pendientes
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();

