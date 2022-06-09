using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Helpers
{
    internal class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var propertyName = bindingContext.ModelName;
            var value = bindingContext.ValueProvider.GetValue(propertyName);

            if(value == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            else
            {
                try
                {
    #pragma warning disable CS8604 // Possible null reference argument.
                    var deserializedValue = JsonConvert.DeserializeObject<T>(value.FirstValue);
    #pragma warning restore CS8604 // Possible null reference argument.
                    bindingContext.Result = ModelBindingResult.Success(deserializedValue);
                }
                catch
                {
                    bindingContext.ModelState.TryAddModelError(propertyName, "The given value is not of correct type");
                }

                return Task.CompletedTask;
            }
        }
    }
}
