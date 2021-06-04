@echo off

dotnet restore

dotnet build --no-restore -c Release

dotnet nuget push Panosen.Text.TextExtension\bin\Release\Panosen.Text.TextExtension.*.nupkg -s https://package.savory.cn/v3/index.json --skip-duplicate

move /Y Panosen.Text.TextExtension\bin\Release\Panosen.Text.TextExtension.*.nupkg D:\LocalSavoryNuget\

pause