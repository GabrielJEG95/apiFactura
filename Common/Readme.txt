MAPEO DE TABLAS AL PROYECTO

dotnet ef dbcontext scaffold "Server=<servidor>;Database=<BD>;User=<usuario>;Password=<contraseña>;" 
Microsoft.EntityFrameworkCore.SqlServer -o Models --schema EsquemaEjemplo -t TablaEjemplo -c DataBaseContext --context-dir Database -f

si se desea mapear un esquema especifico escribir --schema NombreEquema
si se desea mapear una tabla especifica escribir -t nombreTabla
si se desea mapear todo por completo, no especificar tablas ni esquemas despues de Models




--------------------------------------------------------------------------------------------------------------------------
GENERACION DEL PROYECTO PUBLICADO

dotnet publish -c release


--------------------------------------------------------------------------------------------------------------------------
En su Archivo Startup.cs debe agregar en ConfigureServices


services.AddHttpContextAccessor();
services.AddHttpClient<IHttpPermisoServicio, HttpPermisoServicio>();
services.AddHttpClient<IHttpPermisoService, HttpPermisoService>();
services.AddHttpClient<IUsuarioService, UsuarioService>();
