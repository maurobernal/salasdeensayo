using front.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());
// Add Kendo UI services to the services container"
builder.Services.AddKendo();
builder.Services.AddSingleton<ISalaDeEnsayosAPI, SalaDeEnsayoAPI>();
builder.Services.AddSingleton<IInstrumento, Instrumento>();
builder.Services.AddSingleton<IReserva, Reserva>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient("ApiSalaDeEnsayo", h => h.BaseAddress =
new Uri("https://arg.globalassistgroup.com/saladeensayoapi/api/"));

string conn = "Server=172.0.0.14;Database=SEMB;user=TestUser;Password=Test2023!;Encrypt=true;TrustServerCertificate=True";

builder.Services.AddDbContext<IdentityContext>(o => o.UseSqlServer(conn));

builder.Services
    .AddIdentity<IdentityUserDTO, IdentityRole>(options =>
    {

        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
    }

    )
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();


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
    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();

app.Run();