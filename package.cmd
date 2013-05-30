tools\nuget.exe update -self

rd download /s /q

if not exist download mkdir download
if not exist download\package\sportssignup mkdir download\package\sportssignup

if not exist download\package\sportssignup\lib mkdir download\package\sportssignup\lib

tools\ilmerge.exe /lib:src\SSU.Api\bin\Release /internalize /ndebug /v2 /out:download\SSU.Api.dll SSU.Api.dll RestSharp.dll

copy src\SSUApi.Api\bin\Release\*.* download
copy LICENSE.txt download

tools\nuget.exe pack SportsSignup.nuspec -BasePath download\package\sportssignup -o download
