@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.Text.Extension\bin\Release\Panosen.Text.Extension.*.nupkg D:\LocalSavoryNuget\

pause
