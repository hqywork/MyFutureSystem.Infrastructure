@ECHO OFF

CHCP 65001>NUL
cd %~dp0

SETLOCAL

REM 在运行前需修改此项，指示生成 NuGet 包的版本号。
SET VERSION=161208
SET PROJECT=Src\HQY.Future.Infrastructure
SET PackagePath=D:\Codes\NuGetPackageForDebug

REM 设置 dotnet.exe 的路径
SET DotnetCmdPath="%ProgramFiles%\dotnet\dotnet.exe"
IF NOT EXIST %DotnetCmdPath% SET DotnetCmdPath="%ProgramFiles(x86)%\dotnet\dotnet.exe"
IF NOT EXIST %DotnetCmdPath% SET DotnetCmdPath="%ProgramW6432%\dotnet\dotnet.exe"

IF NOT EXIST %PackagePath% MD %PackagePath%

ECHO 正在恢复项目依赖项以及工具 ...
%DotnetCmdPath% restore --disable-parallel

ECHO 正在生成项目（%PROJECT%） ...
%DotnetCmdPath% build "%PROJECT%" --no-incremental --version-suffix %VERSION%

ECHO 正在发布 NuGet 包（%PROJECT%.0.1.0-beta-%VERSION%）...
%DotnetCmdPath% pack "%PROJECT%" --no-build --output "%PackagePath%" --version-suffix %VERSION%

pause;