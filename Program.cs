using BlogdeNotas.Models;
using BlogdeNotas.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

var politicaUsuariosAutenticados = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().Build();



// Add services to the container.
builder.Services.AddControllersWithViews(opc =>
{
    opc.Filters.Add(new AuthorizeFilter(politicaUsuariosAutenticados));
});
builder.Services.AddTransient<IRepositorioNotas, RepositorioNotas>();
builder.Services.AddTransient<IServicioUsuarios, ServicioUsuarios>();
builder.Services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserStore<Usuario>, UsuarioStore>();
builder.Services.AddTransient<SignInManager<Usuario>>();
/*Con esto de Opc Podemos Asignar los requerimientos del tipo
de contrasena OJO
*/
builder.Services.AddIdentityCore<Usuario>(opc =>
{
    opc.Password.RequireDigit = false;
    opc.Password.RequireLowercase = false;
    opc.Password.RequireUppercase = false;
    opc.Password.RequireNonAlphanumeric = false;
});





builder.Services.AddAuthentication(opc =>
{
    opc.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    opc.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    opc.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
    
}).AddCookie(IdentityConstants.ApplicationScheme, opc =>
{
    opc.LoginPath = "/Usuarios/Login";
});
var app = builder.Build();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notas}/{action=Index}/{id?}");

app.Run();
