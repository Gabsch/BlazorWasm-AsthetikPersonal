# publish the app
dotnet publish -c Release -o output src\Gabsch.AsthetikPersonal

# Set the render output (use $PSScriptRoot instead of $pwd inside of *.ps1 script files)
$env:RenderOutputDirectory="$PSScriptRoot/output/wwwroot"

# Generate the output
dotnet test -c Release --filter Category=PreRender