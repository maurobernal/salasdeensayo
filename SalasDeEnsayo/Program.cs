//HOST
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// ********************* SERVICES ********************************
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAppDbContext, AppDbContext>();


builder.Services.AddRateLimiter(delegate (RateLimiterOptions option)
{
    option.AddConcurrencyLimiter("ConcurrencyMinPolicy", delegate (ConcurrencyLimiterOptions options)
    {
        options.PermitLimit = 1;
        options.QueueLimit = 1;
    });

    option.AddConcurrencyLimiter("ConcurrencyModeratePolicy", delegate (ConcurrencyLimiterOptions options)
    {
        options.PermitLimit = 2;
        options.QueueLimit = 2;
    });

    option.AddFixedWindowLimiter("WindowFixed", options =>
    {
        options.PermitLimit = 1;
        options.Window = TimeSpan.FromSeconds(12000);
        options.QueueLimit = 3;
    });

    option.OnRejected = (delegate (OnRejectedContext context, CancellationToken token)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        return new ValueTask();
    });


});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
string conn = "Server=172.0.0.14;Database=SEIB;user=TestUser;Password=Test2023!;Encrypt=true;TrustServerCertificate=True\"";
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(conn));

var app = builder.Build();



// ********************* MIDDLEWARES ********************************
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRateLimiter();
app.UseAuthorization();

app.MapControllers();



// ******************* RUN ********************************************
app.Run();
