using BaseProject.Infrastructure;
using BaseProject.Middlewear;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using UnitofWork;

var builder = WebApplication.CreateBuilder(args);

new IdentityRegister(builder);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;

}); ;
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
new DependencyRegister(builder);
builder.Services.AddCors(options =>
options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddEndpointsApiExplorer();

builder.WebHost.UseUrls("https://192.168.19.23:5001/");
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection conn = s.GetRequiredService<SqlConnection>();
    conn.Open();
    return conn.BeginTransaction();
});
var app = builder.Build();

// Configure the HTTP request pipeline.


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
//Authentication & Authorization
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
//app.UseGloablCustomMiddleware();
//Seed the database
//AppDbInitializer.SeedRolesToDb(app).Wait();

app.Run();