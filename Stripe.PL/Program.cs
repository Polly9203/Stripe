using Serilog;
using Stripe;
using Stripe.BLL;
using Stripe.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

StripeConfiguration.ApiKey = builder.Configuration.GetSection("StripeSettings")["SecretKey"];
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSettings"));

builder.Services.AddStripeBll();
builder.Services.AddStripeDAL(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
