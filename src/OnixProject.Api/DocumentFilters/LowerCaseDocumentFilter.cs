using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace OnixProject.Api.DocumentFilters
{
    public class LowerCaseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths.ToDictionary(
                entry => string.Join('/', entry.Key.Split('/').Select(x => x.ToLower())),
                entry => entry.Value);

            swaggerDoc.Paths = new OpenApiPaths();

            foreach ((string key, OpenApiPathItem value) in paths)
            {
                foreach (OpenApiParameter param in value.Operations.SelectMany(o => o.Value.Parameters))
                {
                    param.Name = param.Name.ToLowerInvariant();
                }

                swaggerDoc.Paths.Add(key, value);
            }
        }
    }
}