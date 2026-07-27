using FinalProjectIT3045.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<FinalProjectTeammatesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinalProjectTeammatesContext")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FinalProjectTeammatesContext>();
    context.Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
