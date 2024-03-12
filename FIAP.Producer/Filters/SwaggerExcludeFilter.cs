using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace FIAP.Producer.Filters;

public class SwaggerExcludeFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties is null || context.Type is null) return;

        var excludedProperties = context.Type.GetProperties()
            .Where(p => p.GetCustomAttribute<SwaggerExcludeAttribute>() != null);

        foreach (var excludedProperty in excludedProperties)
        {
            string key = char.ToLower(excludedProperty.Name[0]) + excludedProperty.Name[1..];
            schema.Properties.Remove(key);
        }
    }
}
