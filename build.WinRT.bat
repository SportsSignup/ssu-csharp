REM tools\nuget.exe update -self

C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /nologo /maxcpucount /nr:true /verbosity:minimal /p:BuildInParallel=true /p:Configuration=Release /p:RestorePackages=true /t:Rebuild src/SSU-CSharp/SSU.WinRT.sln

rd download /s /q

if not exist download mkdir download
if not exist download\package mkdir download\package
if not exist download\package\ssu.winrt mkdir download\package\ssu.winrt

if not exist download\package\ssu.winrt\lib mkdir download\package\ssu.winrt\lib
if not exist download\package\ssu.winrt\lib\windows8 mkdir download\package\ssu.winrt\lib\windows8

copy LICENSE.txt download

copy src\SSU-CSharp\ssu.WinRT\bin\Release\ssu.winmd download\package\ssu.winrt\lib\windows8\
copy src\SSU-CSharp\ssu.WinRT\bin\Release\ssu.pri download\package\ssu.winrt\lib\windows8\

tools\nuget.exe pack SportsSignup-WinRT.nuspec -BasePath download\package\ssu.winrt -o download
