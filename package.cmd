tools\nuget.exe update -self

rd download /s /q

if not exist download mkdir download
if not exist download\package\sportssignup mkdir download\package\sportssignup
if not exist download\package\sportssignup-winrt mkdir download\package\sportssignup-winrt

if not exist download\package\sportssignup\lib mkdir download\package\sportssignup\lib
if not exist download\package\sportssignup-winrt\lib mkdir download\package\sportssignup-winrt\lib

tools\ilmerge.exe /lib:src\SSU-CSharp\SSU.Api\bin\Release /internalize /ndebug /v2 /out:download\SSU.Api.dll SSU.Api.dll RestSharp.dll
tools\ilmerge.exe /lib:src\SSU-CSharp\SSU.WinRT\bin\Release /internalize /ndebug /v2 /out:download\SSU.winmd SSU.winmd RestRT.winmd

copy src\SSU-CSharp\SSUApi.Api\bin\Release\*.* download
copy src\SSU-CSharp\SSU.WinRT\bin\Release\*.* download
copy LICENSE.txt download

tools\nuget.exe pack SportsSignup.nuspec -BasePath download\package\sportssignup -o download
tools\nuget.exe pack SportsSignup-WinRT.nuspec -BasePath download\package\sportssignup-winrt -o download
