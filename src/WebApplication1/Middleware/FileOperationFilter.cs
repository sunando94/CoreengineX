using Microsoft.AspNetCore.JsonPatch.Operations;
using Swashbuckle.SwaggerGen.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.Swagger.Model;
using Microsoft.AspNetCore.Http;

namespace coreenginex.Middleware
{
    public class FileOperationFilter : IOperationFilter
    {
        

        public void Apply(Swashbuckle.Swagger.Model.Operation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.ParameterDescriptions.Any(x => x.ModelMetadata.ContainerType == typeof(IFormFile)))
            {
                operation.Parameters.Remove(operation.Parameters.Where(r => r.Name == "ContentType").First());
                operation.Parameters.Remove(operation.Parameters.Where(r => r.Name == "ContentDisposition").First());
                operation.Parameters.Remove(operation.Parameters.Where(r => r.Name == "Headers").First());
                operation.Parameters.Remove(operation.Parameters.Where(r => r.Name == "Length").First());
                operation.Parameters.Remove(operation.Parameters.Where(r => r.Name == "Name").First());
                operation.Parameters.Remove(operation.Parameters.Where(r => r.Name == "FileName").First());
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "file", // must match parameter name from controller method
                    In = "formData",
                    Description = "Upload file.",
                    Required = true,
                    Type = "file", 
                });
                operation.Consumes.Add("multipart/form-data");

            }

        }
    }
}
