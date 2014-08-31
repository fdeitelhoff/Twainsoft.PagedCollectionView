@echo off

cls

"tools\NuGet\nuget.exe" "install" "FAKE" "-OutputDirectory" "tools" "-ExcludeVersion"

"tools\FAKE\tools\Fake.exe" build.fsx %1

pause