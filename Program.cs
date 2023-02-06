using apiFactura.Services;
using apiFactura.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.OpenApi.Models;
using Common.Attributes;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    /*var groupName = "V1";

    options.SwaggerDoc(groupName, new OpenApiInfo
    {
        Title = $"API Factura {groupName}.0.1",
        Version = groupName,
        Description = "Api-Formunica",
    });*/

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Encabezado de autorización de JWT usando el esquema Bearer. \r\n\r\n Ingrese 'Bearer' [espacio] y luego su token en la entrada de texto a continuación. \r\n\r\n Ejemplo: \" Bearer 12345abcdef \"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
            
    });

    options.OperationFilter<EntidadHeaderSwaggerAttribute>();

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExactusContext>(
    o =>
    {
        o.UseSqlServer(builder.Configuration.GetConnectionString("factura"))
        .ReplaceService<IQueryTranslationPostprocessorFactory,SqlServer2008QueryTranslationPostprocessorFactory>();
    });


builder.Services.AddCors(o => o.AddPolicy("AllowAnyCorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

}));

builder.Services.AddTransient<IFacturaService,FacturaService>(); 
builder.Services.AddTransient<IglobalUsuarioService,globalUsuarioService>();
builder.Services.AddTransient<IGlobalSucurusalServices,GlobalSucurusalServices>();
builder.Services.AddTransient<IccfClienteService,ccfClienteService>();
builder.Services.AddTransient<IglobalVendedoreService,globalVendedoreService>();
builder.Services.AddTransient<IArticuloService,ArticuloService>();
builder.Services.AddTransient<InumeroLetraService,numeroLetraService>();


var app = builder.Build();
    

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
}

if(app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.DocumentTitle = "API Factura V1.0.1"; 
        c.RoutePrefix = string.Empty; 
        c.SwaggerEndpoint("swagger/v1/swagger.json","API Factura v1");
    });
}

app.UseRouting();
app.UseCors("AllowAnyCorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

