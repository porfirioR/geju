# geju
Desarrollo del sistema para gestion de la libreria GeJu
Para crear migracion manualmente
ir a geju\GeJu.Back>
cd .\GeJu.Storage.Sql\
dotnet ef migrations add RoleBlock -s dotnet ef migrations add RoleBlock -s ..\GeJu.Api.Main

revertir
dotnet ef migrations remove -s ..\GeJu.Api.Main

actualizr base de datos
dotnet ef database update -s ..\GeJu.Api.Main


