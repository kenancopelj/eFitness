using eFitnessAPI.Data;
using eFitnessAPI.Services;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Globalization;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("db1")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
    });
});
builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<ISMSService,SMSService>();
builder.Services.AddTransient<IMailService,MailService>();


builder.Services.AddHangfire(configuration => configuration
.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
.UseSimpleAssemblyNameTypeSerializer()
.UseInMemoryStorage()
.UseRecommendedSerializerSettings());
builder.Services.AddHangfireServer();

var culture = new CultureInfo("bs-Latn-BA");
Thread.CurrentThread.CurrentCulture = culture;
Thread.CurrentThread.CurrentUICulture = culture;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.MapHangfireDashboard();
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
    {
        RequireSsl = false,
        SslRedirect = false,
        LoginCaseSensitive = true,
        Users = new []
    {
    new BasicAuthAuthorizationUser
    {
        Login = "username",
        PasswordClear = "password"
        }
    }
    }) }
});

IRecurringJobManager recurringJobManager;
IServiceProvider serviceProvider;
var cancellationToken = new CancellationToken();

RecurringJob.AddOrUpdate<IService>("Run every night//clean files", x =>
    x.ProvjeriClanarine(cancellationToken), "1 0 * * *", TimeZoneInfo.Utc);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("EnableCORS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
