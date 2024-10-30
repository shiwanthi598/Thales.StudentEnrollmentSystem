using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Thales.StudentEnrollmentSystem.DAL;
using Thales.StudentEnrollmentSystem.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
