using ApoioNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);


var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile($"appsettings.json").Build(); 
builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});
builder.Services.AddMvc();


var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/", () => "Hello World!");

app.UseSwaggerUI();

app.UseCors(options =>
{
    options.AllowAnyOrigin(); // Permitir solicitações de qualquer origem
    options.AllowAnyMethod(); // Permitir solicitações de qualquer método (GET, POST, etc.)
    options.AllowAnyHeader(); // Permitir qualquer cabeçalho na solicitação
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();