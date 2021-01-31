# store the solution directory as a variable
SLN_DIR="$(pwd)"

# Build and publish the WebAssembly app
dotnet publish -c Release -o "output" BlazorApp1

# Set the RenderOutputDirectory environment variable
# and run the Prerender test to generate the output
RenderOutputDirectory="${SLN_DIR}/output/wwwroot" \
dotnet test -c Release --filter Category=PreRende