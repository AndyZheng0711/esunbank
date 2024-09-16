using MyWebAPI.Mappings;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //這個設定不能用再用下面這個
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

// 此為使用 Mircosoft.Extensions.Hostting 套件
var services = builder.Services;

services.AddLogging(logging =>
{
    //清除原本的 logging provider
    logging.ClearProviders();
    //設定 logging 的 minmum level 為 trace
    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    //使用 NLog 作為 logging provider
    logging.AddNLog();
});
