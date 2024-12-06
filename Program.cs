using Microsoft.Extensions.DependencyInjection;
using whatsapp_api.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddPolicy(name: "MyPolicy",
        policy => {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

builder.Services.AddHttpClient("WhatsappClient", client => {
    client.BaseAddress = new Uri("http://5.75.139.111:8080/");
    client.DefaultRequestHeaders.Add("apikey", "A5rcI47bdpTI7yib6u4ik0QLthgFWXQQe4eewwfP3gbF6t4fCzUZ1Zc6F8lucLLyjyVjXYw9PjcD78NvH2QT67Tu6hkUHPFQr1osukQECPr0cPT07wpvuekPm0JTAEIP");
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageService, MessageService>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001);
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
