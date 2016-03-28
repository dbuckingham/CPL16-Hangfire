$devenv = 'C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe'
$arguments = "/Clean"

Write-Host "Removing packages folders..." -ForegroundColor Yellow
Get-ChildItem -Recurse -Path "packages" | ForEach-Object { 
    Write-Host "Removing $_..."
    Remove-Item $_ -Recurse 
 }
Write-Host "done." -ForegroundColor Yellow
Write-Host

Write-Host "Cleaning solutions..." -ForegroundColor Yellow
Get-ChildItem -Recurse -Path *.sln | ForEach-Object {
    Write-Host "Cleaning $_..."
    & $devenv $_.FullName $arguments
    Wait-Process -Name devenv
 }
Write-Host "done." -ForegroundColor Yellow