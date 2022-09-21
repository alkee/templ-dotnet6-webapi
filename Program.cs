using System.Reflection;
using webapi;

var builder = WebApplication.CreateBuilder(args);

#region services

builder.Services
    .AddAppSettingsService(builder.Configuration, out var config)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(o => // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    { // swagger UI 설정
        // GenerateDocumentationFile 설정(.csproj)을 이용해 UI 에 반영
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

builder.Services
    .AddControllers();

#endregion


#region service configurations

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
// reverse proxy 를 통할 때 Request.HttpContext.Connection.RemoteIpAddress 로
//   올바른 값을 얻어오기 위해
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders
        = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor
        | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
});
#endregion

app.Run();
