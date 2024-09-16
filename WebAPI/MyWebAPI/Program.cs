using MyWebAPI.Mappings;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //�o�ӳ]�w����ΦA�ΤU���o��
//builder.Services.AddAutoMapper(typeof(FinancialRecordsProfile).Assembly);

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(C =>
    {
        C.RoutePrefix = "";
        C.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Help_V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// �����ϥ� Mircosoft.Extensions.Hostting �M��
var services = builder.Services;

services.AddLogging(logging =>
{
    //�M���쥻�� logging provider
    logging.ClearProviders();
    //�]�w logging �� minmum level �� trace
    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    //�ϥ� NLog �@�� logging provider
    logging.AddNLog();
});
